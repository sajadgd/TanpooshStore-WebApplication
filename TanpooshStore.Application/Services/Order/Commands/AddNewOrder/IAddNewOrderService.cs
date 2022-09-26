using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Order.Commands.AddNewOrder.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Order.Commands.AddNewOrder
{
    public interface IAddNewOrderService
    {
        ResultDto Execute(AddNewOrderRequestDto request);
    }
}
