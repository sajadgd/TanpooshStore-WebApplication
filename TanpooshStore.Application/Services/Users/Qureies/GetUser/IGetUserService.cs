using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Users.Qureies.Dto;

namespace TanpooshStore.Application.Services.Users.Qureies.GetUser
{
    public interface IGetUserService
    {
        GetUserResultDto Execute(GetUserRequestDto request);
    }
}
