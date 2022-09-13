using Microsoft.AspNetCore.Mvc;
using TanpooshStore.Application.Services.Carts;
using TanpooshStore.Common.Utilities;

namespace EndPoint.Site.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly CookieManager _cookieManager;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
            _cookieManager = new CookieManager();
        }
        public IActionResult Index()
        {
            var browserId = _cookieManager.GetBrowserId(HttpContext);
            var model = _cartService.GetMyCart(browserId).Data;
            return View(model);
        }

        public IActionResult AddToCart(int productId)
        {
            var browserId = _cookieManager.GetBrowserId(HttpContext);
            _cartService.AddToCart(productId, browserId);

            return RedirectToAction("Index");
        }

        public IActionResult IncreaseCount(int cartItemId)
        {
            var browserId = _cookieManager.GetBrowserId(HttpContext);
            var model = _cartService.GetMyCart(browserId).Data.CartItems;
            foreach (var item in model)
            {
                if (item.Id == cartItemId)
                {
                    if (_cookieManager.Contains(HttpContext, "BrowserId"))
                    {
                        _cartService.IncreaseCount(cartItemId);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseCount(int cartItemId)
        {
            var browserId = _cookieManager.GetBrowserId(HttpContext);
            var model = _cartService.GetMyCart(browserId).Data.CartItems;
            foreach (var item in model)
            {
                if (item.Id == cartItemId)
                {
                    if (_cookieManager.Contains(HttpContext, "BrowserId"))
                    {
                        _cartService.DecreaseCount(cartItemId);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int productId)
        {
            var browserId = _cookieManager.GetBrowserId(HttpContext);
            var model = _cartService.GetMyCart(browserId).Data.CartItems;
            foreach (var item in model)
            {
                if (item.ProductId == productId)
                {
                    if (_cookieManager.Contains(HttpContext, "BrowserId"))
                    {
                        _cartService.RemoveFromCart(productId, browserId);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
