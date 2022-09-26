using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Order.Queries.GetUserOrder.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Order.Queries.GetUserOrder
{
    public class GetUserOrderService : IGetUserOrderService
    {
        private readonly IDatabaseContext _context;
        public GetUserOrderService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<UserOrderDto>> Execute(int userId)
        {
            var userOrder = _context.Tbl_Order
                .Include(p => p.OrderDeatils)
                .ThenInclude(p => p.Product)
                .Where(x => x.UserId == userId).OrderByDescending(x => x.Id).Select(s => new UserOrderDto
                {
                    OrderId = s.Id,
                    OrderState = s.OrderState,
                    RequestPayId = s.RequestPayId,
                    OrderDetails = s.OrderDeatils.Select(x => new UserOrderDetailsDto
                    {
                        Count = x.Count,
                        OrderDetailId = x.Id,
                        Price = x.Price,
                        ProductId = x.ProductId,
                        ProductName = x.Product.Name
                    }).ToList(),
                }).ToList();

            var result = new ResultDto<List<UserOrderDto>>
            {
                Data = userOrder,
                IsSuccess = true,
                Message = ""
            };
            return result;
        }
    }
}
