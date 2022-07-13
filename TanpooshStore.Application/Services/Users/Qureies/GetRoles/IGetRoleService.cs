using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Users.Qureies.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Users.Qureies.GetRoles
{
    public interface IGetRoleService
    {
        ResultDto<List<GetRoleDto>> Execute();
    }
}
