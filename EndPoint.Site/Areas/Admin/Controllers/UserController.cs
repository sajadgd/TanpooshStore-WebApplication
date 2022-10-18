using EndPoint.Site.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Users.Commands.UserChangeStatus;
using TanpooshStore.Application.Services.Users.Commands.UserEdit;
using TanpooshStore.Application.Services.Users.Commands.UserRegister;
using TanpooshStore.Application.Services.Users.Commands.UserRegister.Dto;
using TanpooshStore.Application.Services.Users.Commands.UserRemove;
using TanpooshStore.Application.Services.Users.Qureies.Dto;
using TanpooshStore.Application.Services.Users.Qureies.GetRoles;
using TanpooshStore.Application.Services.Users.Qureies.GetUser;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserFacad _userFacad;
        public UserController(IUserFacad userFacad)
        {
            _userFacad = userFacad;
        }

        public IActionResult Index(string searchKey, int page= 1, int pageSize=10)
        {
            var model = _userFacad.getUserService.Execute(new GetUserRequestDto
            {
                Page = page,
                PageSize = pageSize,
                SearchKey = searchKey,
            });
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_userFacad.getRoleService.Execute().Data, "Id", "Name"); 
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            var result = _userFacad.registerUserService.Execute(new RegisterRequestDto
            {
                Email = model.Email,
                FullName = model.FullName,
                Roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto
                    {
                        Id= model.RoleId
                    }
                },
                Password = model.Password,
                RePassword = model.RePassword,
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(int userId)
        {
            var result = _userFacad.removeUserService.Execute(userId);
            return Json(result);
        }

        [HttpPost]
        public IActionResult ChangeStatus(int userId)
        {
            var result = _userFacad.changeStatusUserService.Execute(userId);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Edit(int userId, string fullName, string email)
        {
            var result = _userFacad.editUserService.Execute(new EditUserRequestDto
            {
                UserId = userId,
                FullName = fullName,
                Email = email
            });
            return Json(result);
        }
    }
}
