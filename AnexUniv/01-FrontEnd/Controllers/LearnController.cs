using Common;
using Common.ProjectHelpers;
using System.IO;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = RoleNames.Student)]
    public class LearnController : Controller
    {
        [Route("learn/{id}/{lessonId}")]
        public ActionResult Index(int id, int lessonId = 0)
        {
            return View();
        }
    }
}