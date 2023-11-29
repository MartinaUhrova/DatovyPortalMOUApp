using Microsoft.AspNetCore.Mvc;

namespace DatovyPortalWeb.Controllers {
    public class CohortsController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
