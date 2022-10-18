using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Order.Queries.GetAdminOrder.Dto;
using TanpooshStore.Domain.Entities.Order;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
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

        [HttpPost]
        public IActionResult ChangeOrderState(int orderId, int orderState)
        {
            var result = _orderFacad.changeOrderStateService.Execute(orderId, orderState);
            return Json(result);
        }
    }
}
