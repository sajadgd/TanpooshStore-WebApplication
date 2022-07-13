using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Users.Commands.UserEdit
{
    public interface IEditUserService
    {
        ResultDto Execute(EditUserRequestDto request);
    }
}
