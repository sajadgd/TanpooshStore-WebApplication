using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Order.Commands.AddNewOrder.Dto;
using TanpooshStore.Common.Dto;
using TanpooshStore.Domain.Entities.Order;

namespace TanpooshStore.Application.Services.Order.Commands.AddNewOrder
{
    public class AddNewOrderService : IAddNewOrderService
    {
        private readonly IDatabaseContext _context;
        public AddNewOrderService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(AddNewOrderRequestDto request)
        {
            var user = _context.Tbl_Users.Find(request.UserId);
            var requestPay = _context.Tbl_RequestPay.Find(request.RequestPayId);
            var cart = _context.Tbl_Cart
                .Include(c => c.CartItem)
                .ThenInclude(p => p.Product).Where(w => w.Id == request.CartId).FirstOrDefault();

            requestPay.IsPaid = true;
            requestPay.PayDate = DateTime.Now;
            requestPay.RefId = request.RefId;
            requestPay.Authority = request.Authority;

            cart.Finished = true;
            cart.FinishedTime = DateTime.Now;

            OrderEntity order = new OrderEntity()
            {
                Address = "",
                InsertTime = DateTime.Now,
                OrderState = OrderState.Processing,
                RequestPay = requestPay,
                User = user,
            };
            _context.Tbl_Order.Add(order);

            List<OrderDetailEntity> orderDetails = new List<OrderDetailEntity>();
            foreach (var item in cart.CartItem)
            {
                OrderDetailEntity orderDetail = new OrderDetailEntity()
                {
                    Count = item.Count,
                    InsertTime = DateTime.Now,
                    Order = order,
                    Price = item.Product.Price,
                    Product = item.Product,
                };
                orderDetails.Add(orderDetail);
            }
            _context.Tbl_OrderDetail.AddRange(orderDetails);
            _context.SaveChanges();

            var result = new ResultDto
            {
                IsSuccess = true,
                Message = "پرداخت شما با موفقیت انجام شد !",
            };
            return result;
        }
    }
}
