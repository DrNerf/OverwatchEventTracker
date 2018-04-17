using OverwachEventTracker.DAL;
using System.Web.Mvc;

namespace OverwatchEventTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbService m_DbService = new DbService();
        // GET: Home
        public ActionResult Index()
        {
            var nextEvent = m_DbService.GetNextEvent();
            return View(nextEvent);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                m_DbService.Dispose();
            }
        }
    }
}