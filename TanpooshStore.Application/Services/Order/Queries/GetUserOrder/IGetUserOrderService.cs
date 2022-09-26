using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Order.Queries.GetUserOrder.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Order.Queries.GetUserOrder
{
    public interface IGetUserOrderService
    {
        ResultDto<List<UserOrderDto>> Execute(int userId);
    }
}
