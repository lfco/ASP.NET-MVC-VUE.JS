using Common;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = RoleNames.Admin)]
    public class PanelController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Category(int id = 0)
        {
            return Json(null);
        }

        public ActionResult Courses()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
    }
}