using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class FilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
