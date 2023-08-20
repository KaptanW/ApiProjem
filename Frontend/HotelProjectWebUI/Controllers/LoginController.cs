using HotelProjectEntityLayer.Concrete;
using HotelProjectWebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password,false,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Staff");
                }
            }
            return View();
        }
    }
}
