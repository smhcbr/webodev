using kuaforsln.Models;
using kuaforsln.Repository;
using kuaforsln.ViewModels;
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
        private readonly IRepository<Kullanici> kullaniciRepo;

        public HomeController(IRepository<About> aboutRepo, IRepository<Iletisim> iletisimRepo, IRepository<Uzman> uzmanRepo, IRepository<Gallery> galleryRepo, IRepository<Kullanici> kullaniciRepo)
        {
            this.aboutRepo = aboutRepo;
            this.iletisimRepo = iletisimRepo;
            this.uzmanRepo = uzmanRepo;
            this.galleryRepo = galleryRepo;
            this.kullaniciRepo = kullaniciRepo;
        }
        public IActionResult Index() => View();

        public IActionResult About()
        {
            var response = aboutRepo.Get().FirstOrDefault();

            if(response == null)
            {
                response = new();
            }

            return View(response);
        }

        public IActionResult Uzmanlar()
        {
            var response = uzmanRepo.GetAll().Include(u => u.Kullanici).ToList();

            if(response.Count() == 0)
            {
                Kullanici kullanici = kullaniciRepo.Get().FirstOrDefault();
                Uzman entity = new()
                {
                    UzmanAlan = "test alan",
                    Kullanici = kullanici,
                    KullaniciId = kullanici.KullaniciID
                };
                uzmanRepo.Ekle(entity);
                uzmanRepo.Save();
            }

            response = uzmanRepo.GetAll().Include(u => u.Kullanici).ToList();

            return View(response);
        }

        public IActionResult Gallery()
        {
            var response = galleryRepo.GetAll().ToList();

            if (response.Count() == 0)
            {
                Gallery entity = new()
                {
                    ResimAciklama = "test aciklama",
                    ResimYol = "test path",
                    ResimTarihi = DateTime.UtcNow,
                    ResimKullanici = kullaniciRepo.Get().FirstOrDefault()
                };
                galleryRepo.Ekle(entity);
                uzmanRepo.Save();
            }

            return View(response);
        }

        public IActionResult Iletisim()
        {
            var response = iletisimRepo.Get().FirstOrDefault();
            
            if(response == null)
            {
                response = new();
            }

            ContactViewModel viewModel = new();

            viewModel.Contact = response;

            ViewBag.Contact = response;
            ViewBag.Iletisim = response;
            return View(viewModel);
        }
    }
}