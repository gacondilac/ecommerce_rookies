using Microsoft.AspNetCore.Mvc;
using RookiesShop.Dto;
using RookiesShop.CustomerSite.Services;
using Microsoft.AspNetCore.Identity;


namespace RookiesShop.CustomerSite.Controllers
{
    public class AccountController : Controller
    {
        //private readonly UserManager<UserDto> _userManager;
        //private readonly SignInManager<UserDto> _signInManager;
        //private RoleManager<IdentityRole> _roleManager { get; }

        //public AccountController(UserManager<UserDto> userManager, SignInManager<UserDto> signInManager, RoleManager<IdentityRole> roleManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _roleManager = roleManager;
        //}
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto, string ReturnUrl)
        {
            return View(signInDto);
        }

        public IActionResult Register()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDto registerDto)
        //{
        //    return RedirectToAction("Register");
        //}

    }
}