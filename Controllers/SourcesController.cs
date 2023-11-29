using Microsoft.AspNetCore.Mvc;

namespace DatovyPortalWeb.Controllers {
    public class SourcesController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
