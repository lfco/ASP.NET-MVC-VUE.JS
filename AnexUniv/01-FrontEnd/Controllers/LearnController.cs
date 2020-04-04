using Common.ProjectHelpers;
using System.IO;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class LearnController : Controller
    {
        [Route("learn/{id}/{lessonId}")]
        public ActionResult Index(int id, int lessonId = 0)
        {
            return View();
        }
    }
}