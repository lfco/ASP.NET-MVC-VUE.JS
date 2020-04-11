using Common;
using Common.ProjectHelpers;
using Model.Auth;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.IO;
using System.Linq;
using System.Web;

namespace Service
{
    public interface ICourseService
    {
        ResponseHelper AddImage(int id, HttpPostedFileBase file);
        Course Get(int id);
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
            _courseRepo = courseRepo;
            _roleRepo = roleRepo;
            _applicationUserRole = applicationUserRole;
        }

        public ResponseHelper InsertOrUpdateBasicInformation(Course model)
        {
            var rh = new ResponseHelper();
            var newRecord = false;

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id > 0)
                    {
                        var originalCourse = _courseRepo.Single(x => x.Id == model.Id);

                        originalCourse.Name = model.Name;
                        originalCourse.Description = model.Description;
                        originalCourse.Price = model.Price;
                        originalCourse.CategoryId = model.CategoryId;
                        originalCourse.Slug = Slug.Course(model.Id, model.Name);

                        _courseRepo.Update(originalCourse);
                    }
                    else
                    {
                        newRecord = true;

                        model.AuthorId = CurrentUserHelper.Get.UserId;
                        model.Status = Enums.Status.Pending;
                        model.Image1 = "assets/images/courses/no-image.jpg";
                        model.Image2 = model.Image1;

                        var role = _roleRepo.SingleOrDefault(x =>
                            x.Name == RoleNames.Teacher
                        );

                        var hasRole = _applicationUserRole.Find(x =>
                            x.UserId == model.AuthorId
                            && x.RoleId == role.Id
                        ).Any();

                        if (!hasRole)
                        {
                            _applicationUserRole.Insert(new ApplicationUserRole
                            {
                                UserId = model.AuthorId,
                                RoleId = role.Id
                            });
                        }

                        _courseRepo.Insert(model);
                    }

                    ctx.SaveChanges();
                }

                if (newRecord)
                {
                    using (var ctx = _dbContextScopeFactory.Create())
                    {
                        // Obtenemos el registro insertado
                        var originalCourse = _courseRepo.Single(x => x.Id == model.Id);

                        originalCourse.Slug = Slug.Course(model.Id, model.Name);

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

        public Course Get(int id)
        {
            var result = new Course();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _courseRepo.Single(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper AddImage(int id, HttpPostedFileBase file)
        {
            var rh = new ResponseHelper();

            try
            {
                // Creamos la ruta
                var path = DirectoryPath.CourseImage(id);
                DirectoryPath.Create(path);

                // Ahora vamos a crear los nombres para el archivo
                var fileName = path
                               + DateTime.Now.ToString("yyyyMMddHHmmss")
                               + Path.GetExtension(file.FileName);

                // La ruta completa
                var fullPath = HttpContext.Current.Server.MapPath("~/" + fileName);

                // La ruta donde lo vamos guardar
                file.SaveAs(fullPath);

                using (var ctx = _dbContextScopeFactory.Create())
                {
                    // Obtenemos el curso
                    var originalCourse = _courseRepo.Single(x => x.Id == id);

                    // Seteamos la imagen
                    originalCourse.Image1 = fileName;
                    originalCourse.Image2 = fileName;

                    _courseRepo.Update(originalCourse);

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                    rh.Result = fileName;
                }
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
