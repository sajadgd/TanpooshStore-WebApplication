using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Common.Dto;
using TanpooshStore.Domain.Entities.Order;

namespace TanpooshStore.Application.Services.Order.Commands.ChangeOrderState
{
    public class ChangeOrderStateService : IChangeOrderStateService
    {
        private readonly IDatabaseContext _context;
        public ChangeOrderStateService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int orderId, int orderState)
        {
            try
            {
                var order = _context.Tbl_Order.Find(orderId);
                if (order == null)
                {
                    var result1 = new ResultDto
                    {
                        IsSuccess = false,
                        Message = "سفارش مورد نظر یافت نشد !"
                    };
                    return result1;
                }
                if (orderState == 1)
                {
                    order.OrderState = OrderState.Canceled;

                }
                else if (orderState == 2)
                {
                    order.OrderState = OrderState.Delivered;
                }
                _context.SaveChanges();
                string orderStatus = order.OrderState == OrderState.Delivered ? "تحویل شده" : "لغو شده";
                var result = new ResultDto
                {
                    IsSuccess = true,
                    Message = $"وضعیت سفارش به {orderStatus} تغییر کرد ."
                };
                return result;
            }
            catch
            {
                var result2 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "در عملیات مورد نظر خطا پیش آمد !"
                };
                return result2;
            }

        }
    }
}
