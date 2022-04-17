using Microsoft.AspNetCore.Mvc;

namespace MyResume.Controllers
{
    public class AboutController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
