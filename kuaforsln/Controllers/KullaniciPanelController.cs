 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kuaforsln.Models;
using kuaforsln.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace kuaforsln.Controllers
{
    [Authorize(Roles = "user,admin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class KullaniciPanelController : Controller
    {
        private readonly IRepository<Kullanici> kullaniciRepo;
        private readonly IRepository<Randevu> randevuRepo;
        private readonly IRepository<Uzman> uzmanRepo;
        public KullaniciPanelController(IRepository<Kullanici> kullaniciRepo, IRepository<Randevu> randevuRepo, IRepository<Uzman> uzmanRepo)
        {
            this.kullaniciRepo = kullaniciRepo;
            this.randevuRepo = randevuRepo;
            this.uzmanRepo = uzmanRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KisiselAyarlar()
        {
            var kullanici = kullaniciRepo.Get(u => u.KullaniciAdi == HttpContext.User.Identity.Name);
            return View(kullanici);
        }
        [HttpPost]
        public IActionResult KisiselAyarlar(Kullanici postUser)
        {
            kullaniciRepo.Guncelle(postUser);
            kullaniciRepo.Save();
            return RedirectToAction("KisiselAyarlar");
        }

        public IActionResult RandevuYonetimi()
        {
            var kullanici = kullaniciRepo.Get(u => u.KullaniciAdi == HttpContext.User.Identity.Name);
            var app = randevuRepo.Table.Include(a => a.Uzman).Include(a => a.Uzman.Kullanici).Where(a => a.KullaniciId == kullanici.KullaniciID);

            return View(app);
        }

        public IActionResult RandevuOlustur()
        {
            var uzmanlar = uzmanRepo.Table.Include(s => s.Kullanici).Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Kullanici.TamAdi
            }); ;
            ViewBag.Users = new SelectList(uzmanlar, "KullaniciId", "Kullanici.TamAdi");
            return View();
        }

        [HttpPost]
        public IActionResult RandevuOlustur(Randevu randevu)
        {
            randevu.KullaniciId = kullaniciRepo.Table.Where(m => m.KullaniciAdi == HttpContext.User.Identity.Name).Select(s => s.KullaniciID).FirstOrDefault();
            if (DateTime.Now.AddMinutes(60.0) < randevu.RandevuTarih)
            {
                randevuRepo.Ekle(randevu);
                randevuRepo.Save();
                return RedirectToAction("RandevuYonetimi");
            }
            else
            {
                return RedirectToAction("RandevuOlustur");
            }
        }

        public IActionResult RandevuGuncelle(int id)
        {
            var app = randevuRepo.Table.Include(a => a.Uzman).Include(a => a.Uzman.Kullanici).Where(a => a.Id == id).FirstOrDefault();
            ViewBag.user = kullaniciRepo.Table.Where(a => a.KullaniciID == app.KullaniciId).FirstOrDefault();
            return View(app);
        }

        [HttpPost]
        public IActionResult RandevuGuncelle(Randevu randevu, DateTime randevuTarih)
        {
            if ((randevuTarih - DateTime.Now).TotalMinutes > 60.0 && randevuTarih > DateTime.Now)
            {
                randevuRepo.Guncelle(randevu);
                randevuRepo.Save();
                return RedirectToAction("RandevuYonetimi");
            }
            else
            {
                return RedirectToAction("RandevuOlustur");
            }


        }

        public IActionResult RandevuSil(int id)
        {
            randevuRepo.Sil(randevuRepo.Table.Where(m => m.Id == id).FirstOrDefault());
            randevuRepo.Save();
            return RedirectToAction("RandevuYonetimi");
        }
    }
}