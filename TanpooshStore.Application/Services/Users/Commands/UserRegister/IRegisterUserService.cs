using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Users.Commands.UserRegister.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Users.Commands.UserRegister
{
    public interface IRegisterUserService
    {
        ResultDto<RegisterResultDto> Execute(RegisterRequestDto request);
    }
}
