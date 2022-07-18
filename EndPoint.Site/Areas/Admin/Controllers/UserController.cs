using EndPoint.Site.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class UserController : Controller
    {
        private readonly IGetUserService _getUserService;
        private readonly IGetRoleService _getRoleService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IChangeStatusUserService _changeStatusUserService;
        private readonly IEditUserService _editUserService;
        public UserController(IGetUserService getUserService, IGetRoleService getRoleService, IRegisterUserService registerUserService,
            IRemoveUserService removeUserService, IChangeStatusUserService changeStatusUserService, IEditUserService editUserService)
        {
            _getUserService = getUserService;
            _getRoleService = getRoleService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _changeStatusUserService = changeStatusUserService;
            _editUserService = editUserService;
        }

        public IActionResult Index(string searchKey, int page= 1, int pageSize=10)
        {
            var model = _getUserService.Execute(new GetUserRequestDto
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
            ViewBag.Roles = new SelectList(_getRoleService.Execute().Data, "Id", "Name"); 
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            var result = _registerUserService.Execute(new RegisterRequestDto
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
            var result = _removeUserService.Execute(userId);
            return Json(result);
        }

        [HttpPost]
        public IActionResult ChangeStatus(int userId)
        {
            var result = _changeStatusUserService.Execute(userId);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Edit(int userId, string fullName, string email)
        {
            var result = _editUserService.Execute(new EditUserRequestDto
            {
                UserId = userId,
                FullName = fullName,
                Email = email
            });
            return Json(result);
        }
    }
}
