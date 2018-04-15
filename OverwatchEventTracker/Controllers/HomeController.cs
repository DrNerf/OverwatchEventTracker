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
            m_DbService.Test();
            return View();
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