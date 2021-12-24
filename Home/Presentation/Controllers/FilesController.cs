using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class FilesController : Controller
    {
        public FilesController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
