using Microsoft.AspNetCore.Mvc;
using TanpooshStore.Application.Services.Carts;
using TanpooshStore.Common.Utilities;

namespace EndPoint.Site.ViewComponents
{
    public class MiniCart : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly CookieManager _cookieManager;
        public MiniCart(ICartService cartService)
        {
            _cartService = cartService;
            _cookieManager = new CookieManager();
        }

        public IViewComponentResult Invoke()
        {
            var browserId = _cookieManager.GetBrowserId(HttpContext);
            var userId = ClaimsUtility.GetUserId(HttpContext.User);
            var model = _cartService.GetMyCart(browserId, userId).Data;
            return View(viewName: "MiniCart", model);

        }
    }
}
