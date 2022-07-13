using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Users.Commands.UserLogin.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Users.Commands.UserLogin
{
    public interface ILoginUserService
    {
        ResultDto<LoginResultDto> Execute(string userName, string password);
    }
}
