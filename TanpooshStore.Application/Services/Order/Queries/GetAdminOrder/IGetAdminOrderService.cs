using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Order.Queries.GetAdminOrder.Dto;
using TanpooshStore.Common.Dto;
using TanpooshStore.Domain.Entities.Order;

namespace TanpooshStore.Application.Services.Order.Queries.GetAdminOrder
{
    public interface IGetAdminOrderService
    {
        ResultDto<AdminOrderPaginationDto> Execute(AdminOrderRequestDto request);
    }
}
