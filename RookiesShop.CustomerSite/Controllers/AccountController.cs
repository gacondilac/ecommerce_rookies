using Microsoft.AspNetCore.Mvc;
using RookiesShop.Dto;
using RookiesShop.CustomerSite.Services;

namespace RookiesShop.CustomerSite.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }



    }
}