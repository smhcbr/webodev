using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using kuaforsln.Models;
using kuaforsln.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace kuaforsln.Controllers
{
    [Authorize(Roles = "Yonetici", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class YoneticiPanelController : Controller
    {
        private readonly IRepository<Kullanici> kullaniciRepo;
        private readonly IRepository<Randevu> randevuRepo;
        private readonly IRepository<Uzman> uzmanRepo;
        private readonly IRepository<About> aboutRepo;
        private readonly IRepository<Iletisim> iletisimRepo;
        private readonly IRepository<IletisimForm> iformRepo;
        private readonly IRepository<Yetki> yetkiRepo;
        private readonly IRepository<Gallery> galleryRepo;
        public YoneticiPanelController(IRepository<Kullanici> kullaniciRepo, IRepository<Randevu> randevuRepo, IRepository<Uzman> uzmanRepo, IRepository<Iletisim> iletisimRepo, IRepository<About> aboutRepo, IRepository<IletisimForm> iformRepo, IRepository<Yetki> yetkiRepo, IRepository<Gallery> galleryRepo)
        {
            this.kullaniciRepo = kullaniciRepo;
            this.yetkiRepo = yetkiRepo;
            this.randevuRepo = randevuRepo;
            this.iformRepo = iformRepo;
            this.aboutRepo = aboutRepo;
            this.uzmanRepo = uzmanRepo;
            this.iletisimRepo = iletisimRepo;
            this.galleryRepo = galleryRepo;
        }

        public IActionResult Index() => View();
        
        public IActionResult KullaniciYonetimi() => View(kullaniciRepo.GetAll().Include(u => u.Yetki));

        public IActionResult KullaniciEkle() => View();
        
        public IActionResult KullaniciGuncelle(int id) => View(kullaniciRepo.Table.Where(u => u.KullaniciID == id).FirstOrDefault());

        [HttpPost]
        public IActionResult KullaniciEkle(Kullanici kullanici, int secilenRol)
        {
            kullanici.YetkiId = secilenRol;
            kullaniciRepo.Ekle(kullanici);
            kullaniciRepo.Save();
            return RedirectToAction("KullaniciYonetimi");
        }
        
        [HttpPost]
        public IActionResult KullaniciGuncelle(Kullanici kullanici, int secilenRol)
        {
            kullanici.YetkiId = secilenRol;
            kullaniciRepo.Guncelle(kullanici);
            kullaniciRepo.Save();
            return RedirectToAction("KullaniciYonetimi");
        }
        
        public IActionResult KullaniciSil(int id)
        {
            kullaniciRepo.Sil(kullaniciRepo.Table.Where(u => u.KullaniciID == id).FirstOrDefault());
            kullaniciRepo.Save();
            return RedirectToAction("KullaniciYonetimi");
        }

        public IActionResult RandevuYonetimi() =>
            View(randevuRepo.GetAll().Include(u => u.Kullanici).Include(u => u.Uzman.Kullanici));

        public IActionResult RandevuGuncelle(int id)
        {
            var randevu = randevuRepo.Table.Where(u => u.KullaniciId == id).FirstOrDefault();            
            ViewBag.Kullanici = kullaniciRepo.Table.Where(u => u.KullaniciID == id).FirstOrDefault();
            return View(randevu);
        }

        [HttpPost]
        public IActionResult RandevuGuncelle(Randevu randevu)
        {
            randevuRepo.Guncelle(randevu);
            randevuRepo.Save();
            return RedirectToAction("RandevuYonetimi");
        }

        public IActionResult RandevuSil(int id)
        {
            randevuRepo.Sil(randevuRepo.Table.Where(u => u.KullaniciId == id).FirstOrDefault());
            randevuRepo.Save();
            return RedirectToAction("RandevuYonetimi");
        }

        public IActionResult iFormYonetimi() => View(iformRepo.GetAll());
        
        [HttpPost, AllowAnonymous]
        public IActionResult iFormEkle(IletisimForm iletisimForm)
        {
            iformRepo.Ekle(iletisimForm);
            iformRepo.Save();
            return Redirect("~/Home/Iletisim");
        }
        public IActionResult iFormSil(int id)
        {
            var iForm = iformRepo.Table.Where(u => u.Id == id).FirstOrDefault();
            iformRepo.Sil(iForm);
            iformRepo.Save();
            return RedirectToAction("iFormYonetimi");
        }

        public IActionResult UzmanYonetimi() => View(uzmanRepo.GetAll().Include(u => u.Kullanici));

        public IActionResult UzmanEkle()
        {
            ViewBag.kullanicilar = new SelectList(kullaniciRepo.GetAll().Where(u => !uzmanRepo.GetAll().Select(s => s.KullaniciId).Include(u.KullaniciAdi)), "Id", "TamAdi");
            return View();
        }

        [HttpPost]
        public IActionResult UzmanEkle(Uzman uzman)
        {
            uzmanRepo.Ekle(uzman);
            uzmanRepo.Save();
            return RedirectToAction("UzmanYonetimi");
        }

        public IActionResult UzmanGuncelle(int id)
        {
            var uzman = uzmanRepo.Table.Where(u => u.KullaniciId == id).FirstOrDefault();
            ViewBag.tamAdi = kullaniciRepo.Table.Where(u => u.KullaniciID == id).FirstOrDefault().TamAdi;
            return View(uzman);
        }

        [HttpPost]
        public IActionResult UzmanGuncelle(Uzman uzman)
        {
            uzmanRepo.Guncelle(uzman);
            uzmanRepo.Save();
            return RedirectToAction("UzmanYonetimi");
        }


        public IActionResult UzmanSil(int id)
        {
            var uzman = uzmanRepo.Table.Where(u => u.KullaniciId == id).FirstOrDefault();
            uzmanRepo.Sil(uzman);
            uzmanRepo.Save();
            return RedirectToAction("UzmanYonetimi");
        }

        public IActionResult AboutYonetimi() => View(aboutRepo.Get().FirstOrDefault());

        [HttpPost]
        public IActionResult AboutYonetimi(About about)
        {
            aboutRepo.Guncelle(about);
            aboutRepo.Save();
            return RedirectToAction("AboutYonetimi");
        }

        public IActionResult IletisimYonetimi() => View(iletisimRepo.Get().FirstOrDefault());

        [HttpPost]
        public IActionResult IletisimYonetimi(Iletisim iletisim)
        {
            iletisimRepo.Guncelle(iletisim);
            iletisimRepo.Save();
            return RedirectToAction("IletisimYonetimi");
        }

        public IActionResult GalleryYonetimi() => View(galleryRepo.GetAll().Include(u => u.ResimKullanici));

        public IActionResult GalleryEkle() => View();

        [HttpPost]
        public IActionResult GalleryEkle(Gallery gallery, IFormFile galleryResim)
        {
            if (galleryResim != null)
            {
                var kullaniciId = kullaniciRepo.Get().FirstOrDefault();
                gallery.ResimTarihi = DateTime.Now;

                var filename = galleryResim.FileName;
                var fileinfo = new FileInfo(filename);
                string imgYol =
                    $"img-{gallery.ResimTarihi:dd-MM-yyyy-HH-mm}-{new Random().Next(1000, 10000)}{fileinfo.Extension}";
                gallery.ResimYol = imgYol;

                using (var localFile = System.IO.File.OpenWrite("wwwroot/img/" + imgYol))
                using (var yuklenenDosya = galleryResim.OpenReadStream())
                {
                    yuklenenDosya.CopyTo(localFile);
                }

            }
            
            galleryRepo.Ekle(gallery);
            galleryRepo.Save();
            return RedirectToAction("GalleryYonetimi");
        }

        public IActionResult GalleryGuncelle(int id)
        {
            var gallery = galleryRepo.Table.Where(u => u.Id == id).FirstOrDefault();
            ViewBag.userFullName = kullaniciRepo.Table.Where(u => u.KullaniciID == id).FirstOrDefault().TamAdi;
            return View(gallery);
        }

        [HttpPost]
        public IActionResult GalleryGuncelle(Gallery gallery)
        {
            galleryRepo.Guncelle(gallery);
            galleryRepo.Save();
            return RedirectToAction("GalleryGuncelle");
        }

        public IActionResult GallerySil(int id) => RedirectToAction("GalleryYonetimi", galleryRepo.Sil(galleryRepo.Table.Where(u => u.Id == id).FirstOrDefault()));
    }
}