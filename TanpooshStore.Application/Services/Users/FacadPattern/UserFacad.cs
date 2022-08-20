using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Users.Commands.UserChangeStatus;
using TanpooshStore.Application.Services.Users.Commands.UserEdit;
using TanpooshStore.Application.Services.Users.Commands.UserLogin;
using TanpooshStore.Application.Services.Users.Commands.UserRegister;
using TanpooshStore.Application.Services.Users.Commands.UserRemove;
using TanpooshStore.Application.Services.Users.Qureies.GetRoles;
using TanpooshStore.Application.Services.Users.Qureies.GetUser;

namespace TanpooshStore.Application.Services.Users.FacadPattern
{
    public class UserFacad: IUserFacad
    {
        private readonly IDatabaseContext _context;
        public UserFacad(IDatabaseContext context)
        {
            _context = context;
        }

        private readonly GetUserService _getUserService;
        public GetUserService getUserService
        {
            get { return _getUserService ?? new GetUserService(_context); }
        }

        private readonly GetRoleService _getRoleService;
        public GetRoleService getRoleService
        {
            get { return _getRoleService ?? new GetRoleService(_context); }
        }

        private readonly RegisterUserService _registerUserService;
        public RegisterUserService registerUserService
        {
            get { return _registerUserService ?? new RegisterUserService(_context); }
        }

        private readonly LoginUserService _loginUserService;
        public LoginUserService loginUserService
        {
            get { return _loginUserService ?? new LoginUserService(_context); }
        }

        private readonly RemoveUserService _removeUserService;
        public RemoveUserService removeUserService
        {
            get { return _removeUserService ?? new RemoveUserService(_context); }
        }

        private readonly ChangeStatusUserService _changeStatusUserService;
        public ChangeStatusUserService changeStatusUserService
        {
            get { return _changeStatusUserService ?? new ChangeStatusUserService(_context); }
        }

        private readonly EditUserService _editUserService;
        public EditUserService editUserService
        {
            get { return _editUserService ?? new EditUserService(_context); }
        }
    }
}
