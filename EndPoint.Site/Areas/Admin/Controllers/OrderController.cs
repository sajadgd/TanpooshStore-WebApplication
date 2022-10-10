using Microsoft.AspNetCore.Mvc;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Order.Queries.GetAdminOrder.Dto;
using TanpooshStore.Domain.Entities.Order;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderFacad _orderFacad;
        public OrderController(IOrderFacad orderFacad)
        {
            _orderFacad = orderFacad;
        }
        public IActionResult Index(OrderState orderState, int page=1, int pageSize=10)
        {
            var model = _orderFacad.getAdminOrderService.Execute(new AdminOrderRequestDto
            {
                Page = page,
                PageSize = pageSize,
                OrderState = orderState
            }).Data;
            return View(model);
        }
    }
}
