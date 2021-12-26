using Microsoft.AspNetCore.Mvc;

namespace WebApplication1_del.Controllers
{
    public class FilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
