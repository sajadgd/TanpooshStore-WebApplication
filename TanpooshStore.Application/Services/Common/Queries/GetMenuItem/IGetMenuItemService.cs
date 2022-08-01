using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Common.Queries.GetMenuItem.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Common.Queries.GetMenuItem
{
    public interface IGetMenuItemService
    {
        ResultDto<List<GetMenuItemDto>> Execute();
    }
}
