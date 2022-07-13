using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Users.Commands.UserChangeStatus
{
    public interface IChangeStatusUserService
    {
        ResultDto Execute(int Id);
    }
}
