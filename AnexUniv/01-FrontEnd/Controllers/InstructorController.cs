using Common;
using FrontEnd.App_Start;
using FrontEnd.ViewModels;
using Model.Domain;
using Service;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class InstructorController : Controller
    {
        private ICourseService _courseService = DependecyFactory.GetInstance<ICourseService>();
        private ICategoryService _categoryService = DependecyFactory.GetInstance<ICategoryService>();
        private IInstructorService _instructorService = DependecyFactory.GetInstance<IInstructorService>();

        // GET: Course
        [Authorize(Roles = RoleNames.Teacher)]
        public ActionResult Index()
        {
            return View(
                _instructorService.GetAll(CurrentUserHelper.Get.UserId)
            );
        }

        public ActionResult GetWidget()
        {
            var model = _instructorService.Widget(CurrentUserHelper.Get.UserId);

            return Json(model);
        }

        public ActionResult CreateCourse()
        {
            var model = new CourseBasicInformationViewModel();
            model.Categories = _categoryService.GetAll();
            model.Course = new Course();

            return View(model);
        }

        [HttpPost]
        public JsonResult SaveCourse(Course model)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else
            {
                rh = _courseService.InsertOrUpdateBasicInformation(model);
                if (rh.Response)
                {
                    rh.Href = "Instructor";
                }
            }

            return Json(rh); 
        }

        public ActionResult Course(int id)
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save()
        {
            return Json(null);
        }
    }
}