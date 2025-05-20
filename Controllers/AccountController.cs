using LOGINPRUEBA.web.Helpers;
using LOGINPRUEBA.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LOGINPRUEBA.web.Controllers
{
    public class AccountController(IUserHelper userHelper) : Controller
    {
        public bool IsPostBack { get; private set; }
        private readonly IUserHelper _userHelper = userHelper;

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated!)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First()!);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Usuario o contraseña no valido.");
            model.Password = string.Empty;
            return View(model);
        }

        public async Task<IActionResult> Logout(LoginViewModel model)
        {
            //************agregado por el sistema***********
            ArgumentNullException.ThrowIfNull(model);
            //**********************************************

            await _userHelper.LogoutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult NotAuthorized()
        {
            return View();
        }
    }
}