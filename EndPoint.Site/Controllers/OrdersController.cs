using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Common.Utilities;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderFacad _orderFacad;
        public OrdersController(IOrderFacad orderFacad)
        {
            _orderFacad = orderFacad;
        }

        public IActionResult Index()
        {
            int userId = ClaimsUtility.GetUserId(User).Value;
            var model = _orderFacad.getUserOrderService.Execute(userId).Data;
            return View(model);
        }
    }
}
