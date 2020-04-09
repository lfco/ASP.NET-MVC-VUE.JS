using Common;
using Common.ProjectHelpers;
using Model.Auth;
using Model.Custom;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.DbContextScope.Extensions;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICourseService
    {
        ResponseHelper InsertOrUpdateBasicInformation(Course model);
    }

    public class CourseService : ICourseService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<ApplicationRole> _roleRepo;
        private readonly IRepository<ApplicationUserRole> _applicationUserRole;

        public CourseService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Course> courseRepo,
            IRepository<ApplicationRole> roleRepo,
            IRepository<ApplicationUserRole> applicationUserRole
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _roleRepo = roleRepo;
            _courseRepo = courseRepo;
            _applicationUserRole = applicationUserRole;
        }

        public ResponseHelper InsertOrUpdateBasicInformation(Course model)
        {
            var rh = new ResponseHelper();
            var newRecord = false;
            try
            {
                using (var cxt = _dbContextScopeFactory.Create())
                {
                    // Si es mayor que 0 es un Update
                    if (model.Id > 0)
                    {
                        var originalCourse = _courseRepo.Single(x => x.Id == model.Id);

                        originalCourse.Name = model.Name;
                        originalCourse.CategoryId = model.CategoryId;
                        originalCourse.Slug = model.Slug;
                        originalCourse.Price = model.Price;
                        originalCourse.Description = model.Description;

                        _courseRepo.Update(originalCourse);
                    }
                    else
                    {
                        newRecord = true;

                        model.UserAuthorId = CurrentUserHelper.Get.UserId;
                        model.Status = Enums.Status.Pending;
                        model.Image1 = "assets/images/courses/no-image.jpg";
                        model.Image2 = model.Image1;

                        var role = _roleRepo.SingleOrDefault(x => 
                        x.Name == RoleNames.Teacher);

                        var hasRole = _applicationUserRole.Find(x =>
                        x.UserId == model.UserAuthorId 
                        && x.RoleId == role.Id
                        ).Any();

                        if (!hasRole)
                        {
                            _applicationUserRole.Insert(new ApplicationUserRole
                            {
                                UserId = model.UserAuthorId,
                                RoleId = role.Id

                            });
                        }

                        _courseRepo.Insert(model);
                    }
                    cxt.SaveChanges();
                }

                if (newRecord)
                {
                    using (var ctx = _dbContextScopeFactory.Create())
                    {
                        // Obtenemos el registro insertado
                        var originalCourse = _courseRepo.Single(x => x.Id == model.Id);

                        originalCourse.Slug = Slug.Category(model.Id, model.Name);

                        // Actualizamos
                        _courseRepo.Update(originalCourse);

                        ctx.SaveChanges();
                    }
                }

                rh.SetResponse(true);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }

            return rh;
        }
    }
}
