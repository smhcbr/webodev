using kuaforsln.Models;
using kuaforsln.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace kuaforsln.Controllers
{
    [AllowAnonymous]
    [Authorize(Roles = "user,admin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        private readonly IRepository<About> aboutRepo;
        private readonly IRepository<Iletisim> iletisimRepo;
        private readonly IRepository<Uzman> uzmanRepo;
        private readonly IRepository<Gallery> galleryRepo;

        public HomeController(IRepository<About> aboutRepo, IRepository<Iletisim> iletisimRepo, IRepository<Uzman> uzmanRepo, IRepository<Gallery> galleryRepo)
        {
            this.aboutRepo = aboutRepo;
            this.iletisimRepo = iletisimRepo;
            this.uzmanRepo = uzmanRepo;
            this.galleryRepo = galleryRepo;
        }
        public IActionResult Index() => View();

        public IActionResult About() => View(aboutRepo.Get().FirstOrDefault());

        public IActionResult Uzmanlar() => View(uzmanRepo.GetAll().Include(u => u.Kullanici));

        public IActionResult Gallery() => View(galleryRepo.GetAll());

        public IActionResult Iletisim()
        {
            ViewBag.Contact = iletisimRepo.Get().FirstOrDefault();
            return View();
        }
    }
}