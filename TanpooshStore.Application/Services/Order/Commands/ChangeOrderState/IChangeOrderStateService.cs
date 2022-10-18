using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Order.Commands.ChangeOrderState
{
    public interface IChangeOrderStateService
    {
        ResultDto Execute(int orderId, int orderState);
    }
}
