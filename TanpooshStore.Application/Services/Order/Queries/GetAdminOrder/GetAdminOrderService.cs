using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Order.Queries.GetAdminOrder.Dto;
using TanpooshStore.Common;
using TanpooshStore.Common.Dto;
using TanpooshStore.Domain.Entities.Order;

namespace TanpooshStore.Application.Services.Order.Queries.GetAdminOrder
{
    public class GetAdminOrderService : IGetAdminOrderService
    {
        private readonly IDatabaseContext _context;
        public GetAdminOrderService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<AdminOrderPaginationDto> Execute(AdminOrderRequestDto request)
        {
            var order = _context.Tbl_Order
                .Include(p => p.OrderDeatils)
                .Where(o => o.OrderState == request.OrderState)
                .OrderByDescending(o => o.Id).AsQueryable();

            int rowCount;
            var orderResult = order.ToPaged(request.Page, request.PageSize, out rowCount)
                .Select(o => new AdminOrderDto
                {
                    InsertTime = o.InsertTime,
                    OrderId = o.Id,
                    OrderState = o.OrderState,
                    ProductCount = o.OrderDeatils.Count(),
                    RequestPayId = o.RequestPayId,
                    UserId = o.UserId,
                }).ToList();

            var result = new ResultDto<AdminOrderPaginationDto>
            {
                Data = new AdminOrderPaginationDto
                {
                    PageSize = request.PageSize,
                    Page = request.Page,
                    RowCount = rowCount,
                    Orders = orderResult,
                },
                IsSuccess = true,
            };
            return result;
        }
    }
}
