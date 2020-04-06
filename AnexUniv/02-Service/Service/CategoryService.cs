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
    public interface ICategoryService {
        ResponseHelper InsertOrUpdate(Category model);
    }
    public class CategoryService : ICategoryService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Category> _categoryRepo;

        public CategoryService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Category> categoryRepo
         )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _categoryRepo = categoryRepo;        
        }

        public ResponseHelper InsertOrUpdate(Category model)
        {
            var rh = new ResponseHelper();
            var newRecord = false;

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id > 0)
                    {
                        var originalCategory = _categoryRepo.Single(x => x.Id == model.Id);

                        originalCategory.Name = model.Name;
                        originalCategory.Icon = model.Icon;

                        _categoryRepo.Insert(model);
                    }
                    else
                    {
                        newRecord = true;
                        _categoryRepo.Insert(model);
                    }

                    ctx.SaveChanges();
                }

                if (newRecord)
                {
                    using (var ctx = _dbContextScopeFactory.Create())
                    {
                        //Obtenemos el registro insertado
                        var originalCategory = _categoryRepo.Single(x => x.Id == model.Id);

                        originalCategory.Slug = Slug.Category(model.Id, model.Name);
                        // Actualizamos
                        _categoryRepo.Update(originalCategory);

                        ctx.SaveChanges();
                    }
                    rh.SetResponse(true);
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
