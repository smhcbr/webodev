using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using kuaforsln.Models;
using kuaforsln.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kuaforsln.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class GirisController : Controller
    {
        private readonly IRepository<Kullanici> kullaniciRepo;

        public GirisController(IRepository<Kullanici> kullaniciRepo)
        {
            this.kullaniciRepo = kullaniciRepo;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect(User.IsInRole("admin") ? "~/Admin" : "~/KullaniciView");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Kullanici kullanici)
        {
            var user = kullaniciRepo.GetAll()
                .Include(u => u.Yetki)
                .FirstOrDefault(u => u.KullaniciAdi == kullanici.KullaniciAdi && u.Sifre == kullanici.Sifre);

            if (user == null) return RedirectToAction("Index");

            await SignInAsync(user);
            return Redirect(user.Yetki.RoleAdi == "admin" ? "~/AdminPanel" : "~/KullaniciView");
        }

        public async Task SignInAsync(Kullanici kullanici)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, kullanici.Yetki.RoleAdi),
                new Claim(ClaimTypes.Name, kullanici.KullaniciAdi),
                new Claim(ClaimTypes.NameIdentifier, kullanici.KullaniciID.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(Kullanici kayitliKullanici)
        {
            kayitliKullanici.YetkiId = 2;
            var user = kullaniciRepo.GetAll().FirstOrDefault(u => u.KullaniciAdi == kayitliKullanici.KullaniciAdi);

            if (user == null)
            {
                kullaniciRepo.Ekle(kayitliKullanici);
                kullaniciRepo.Save();
                await SignInAsync(kayitliKullanici);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Register");
        }
    }
}