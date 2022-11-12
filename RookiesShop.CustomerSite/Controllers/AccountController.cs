using Microsoft.AspNetCore.Mvc;
using RookiesShop.Dto;
using RookiesShop.CustomerSite.Services;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;


namespace RookiesShop.CustomerSite.Controllers
{
    [Route("/[controller]/[action]")]
    public class AccountController : Controller
    {
     
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService= accountService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            if(ModelState.IsValid)
            {
                string stringData =await _accountService.SignIn(signInDto);
                if(stringData != null)
                {
                    var cookieOption = new CookieOptions()
                    {
                        HttpOnly = true,
                        Expires = DateTime.UtcNow.AddMinutes(15),
                        IsEssential = true
                    };
                    Response.Cookies.Append("jwtToken", stringData, cookieOption);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email and password");
                }
            }

            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult LogOut()
        {
            //
            Response.Cookies.Delete("jwtToken");
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {

            if (ModelState.IsValid)
            {
                string stringData = await _accountService.Register(registerDto);

                if (stringData == "true")
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to register");
                }
            }
            return RedirectToAction("Register");
        }

    }
}