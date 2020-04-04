using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class CourseController : Controller
    {
        [Route("course/{id}/{slug}")]
        public ActionResult Index(int id, string slug)
        {
            return View();
        }

        [Route("category/{id}/{slug}")]
        public ActionResult Category(int id, string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return Redirect("~");
            }

            ViewBag.Title = slug;
            return View();
        }
    }
}