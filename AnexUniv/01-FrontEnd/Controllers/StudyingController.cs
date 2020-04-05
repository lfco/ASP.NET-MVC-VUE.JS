using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class StudyingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}