using Common;
using FrontEnd.App_Start;
using Model.Domain;
using Service;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = RoleNames.Admin)]
    public class PanelController : Controller
    {
        private IUserService _userService = DependecyFactory.GetInstance<IUserService>();
        private ICategoryService _categoryService = DependecyFactory.GetInstance<ICategoryService>();

        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }

        public JsonResult GetCategory(int id)
        {
            return Json(
                _categoryService.Get(id)
            );
        }

        [HttpPost]
        public JsonResult GetCategories(AnexGRID grid)
        {
            return Json(
                _categoryService.GetAll(grid)
            );
        }

        [HttpPost]
        public JsonResult Category(int id = 0)
        {
            return Json(null);
        }

        [HttpPost]
        public JsonResult CategorySave(Category model)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else 
            {
                rh = _categoryService.InsertOrUpdate(model);
                if (rh.Response)
                {
                    rh.Href = "self";
                }
            }

            return Json(rh);
        }

        [HttpPost]
        public JsonResult DeleteCategory(int id)
        {
            return Json(
              _categoryService.Delete(id)
            );
        }

        public ActionResult Courses()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUsers(AnexGRID grid)
        {
            return Json(
                _userService.GetAll(grid)
            );
        }
    }
}