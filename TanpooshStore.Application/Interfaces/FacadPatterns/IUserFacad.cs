using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Users.Commands.UserChangeStatus;
using TanpooshStore.Application.Services.Users.Commands.UserEdit;
using TanpooshStore.Application.Services.Users.Commands.UserLogin;
using TanpooshStore.Application.Services.Users.Commands.UserRegister;
using TanpooshStore.Application.Services.Users.Commands.UserRemove;
using TanpooshStore.Application.Services.Users.Qureies.GetRoles;
using TanpooshStore.Application.Services.Users.Qureies.GetUser;

namespace TanpooshStore.Application.Interfaces.FacadPatterns
{
    public interface IUserFacad
    {
        /// <summary>
        /// گرفتن لیست کاربران
        /// </summary>
        GetUserService getUserService { get; }
        /// <summary>
        /// گرفتن لیست نقش ها
        /// </summary>
        GetRoleService getRoleService { get; }
        RegisterUserService registerUserService { get; }
        LoginUserService loginUserService { get; }
        RemoveUserService removeUserService { get; }
        ChangeStatusUserService changeStatusUserService { get; }
        EditUserService editUserService { get; }
    }
}
