using Covid_Postgres.DI.Interface;
using Covid_Postgres.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Covid_Postgres.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _iaccountRepository;

        public AccountController (IAccountRepository accountRepository)
        {
            _iaccountRepository = accountRepository;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm request)
        {
            var x = _iaccountRepository.Login(request);
            if (ModelState.IsValid)
            {
                if (x == true)
                {
                    var claims = new List<Claim>           //tạo Claim chứ thông tin user
                    {
                        new Claim(ClaimTypes.Name,request.Username),
                        new Claim("FullName", request.Username),
                        new Claim(ClaimTypes.Role, "Administrator"),
                    };

                    var claimsIdentity = new ClaimsIdentity(   //Create a ClaimsIdentity with any required Claims and call SignInAsync to sign in the user:
                claims, CookieAuthenticationDefaults.AuthenticationScheme);  

                    var authProperties = new AuthenticationProperties
                    {

                        RedirectUri = "/Home/Index",   //trả về trang yêu cầu

                    };

                    await HttpContext.SignInAsync(  //SignInAsync creates an encrypted cookie and adds it to the current response. If AuthenticationScheme isn't specified, the default scheme is used.
              CookieAuthenticationDefaults.AuthenticationScheme,
              new ClaimsPrincipal(claimsIdentity),  //To create a cookie holding user information, construct a ClaimsPrincipal. The user information is serialized and stored in the cookie.
              authProperties);
                }
                else
                {
                    ViewBag.Login = "Tài khoản hoặc mật khẩu không chính xác!";
                }    
            }
            return View(request);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
    CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
