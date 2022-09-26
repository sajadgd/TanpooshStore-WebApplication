using EndPoint.Site.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Users.Commands.UserLogin;
using TanpooshStore.Application.Services.Users.Commands.UserRegister;
using TanpooshStore.Application.Services.Users.Commands.UserRegister.Dto;
using TanpooshStore.Common.Dto;

namespace EndPoint.Site.Controllers
{
    public class LoginRegisterController : Controller
    {
        private readonly IUserFacad _userFacad;
        public LoginRegisterController(IUserFacad userFacad)
        {
            _userFacad = userFacad;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel request)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "در حال حاضر نمیتوانید ثبت نام مجدد نمایید !" });
            }
            var signupResult = _userFacad.registerUserService.Execute(new RegisterRequestDto
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password,
                RePassword = request.RePassword,
                Roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto{Id = 3}
                }
            });
            if (signupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, signupResult.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Name, request.FullName),
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Role, "Customer")
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);
            }
            return Json(signupResult);
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var loginResult = _userFacad.loginUserService.Execute(email, password);
            if (loginResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, loginResult.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name, loginResult.Data.FullName) 
                };
                foreach (var item in loginResult.Data.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }   
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5)
                };
                HttpContext.SignInAsync(principal, properties);
            }
            return Json(loginResult);
        }

        [HttpGet]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult ForgotPassword()
        {
            return View("ForgotPasswordConfirmation");
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
