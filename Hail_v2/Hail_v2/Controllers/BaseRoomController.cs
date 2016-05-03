using Hail_v2.Models;
using System.Web.Mvc;

namespace Hail_v2.Controllers
{
    public class BaseRoomController : Controller
    {
        public ActionResult Base(string name)
        {
            return View(new BaseTitle() { Name = name });
        }

        public ActionResult Constructor(string name)
        {
            return View(new BaseTitle() { Name = name });
        }

        public ActionResult Enter(string name)
        {
            return View(new BaseTitle() { Name = name });
        }
    }
}