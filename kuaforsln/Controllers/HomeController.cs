using Microsoft.AspNetCore.Mvc;

namespace kuaforsln.Controllers
{
    public class HomeController:Controller
    {
        public string Index()
        {
            return "home/index";
        }

        public IActionResult About()
        {
            return View();
        }

        public string Gallery(int id)
        {
            return "home/gallery/" + id;
        }
    }
}