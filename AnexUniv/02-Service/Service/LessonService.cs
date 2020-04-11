using Common;
using Model.Auth;
using Model.Custom;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.DbContextScope.Extensions;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ILessonService
    {
        ResponseHelper Insert(LessonsPerCourse model);
    }

    public class LessonService : ILessonService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<LessonsPerCourse> _lessonRepo;

        public LessonService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<LessonsPerCourse> lessonRepo
        )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _lessonRepo = lessonRepo;
        }

        public ResponseHelper Insert(LessonsPerCourse model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    model.Content = string.Format("Contenido para la lección {0}", model.Name);
                    _lessonRepo.Insert(model);
                    ctx.SaveChanges();

                    rh.SetResponse(true);
                }
            }
            catch (DbEntityValidationException e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
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
