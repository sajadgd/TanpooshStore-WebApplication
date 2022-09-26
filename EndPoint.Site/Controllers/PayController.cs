using Dto.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Carts;
using TanpooshStore.Application.Services.Order.Commands.AddNewOrder.Dto;
using TanpooshStore.Common.Utilities;
using ZarinPal.Class;

namespace EndPoint.Site.Controllers
{
    [Authorize("Customer")]
    public class PayController : Controller
    {
        private readonly IFinancesFacad _financesFacad;
        private readonly ICartService _cartService;
        private readonly CookieManager _cookieManager;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly IOrderFacad _orderFacad;
        public PayController(IFinancesFacad financesFacad, ICartService cartService, IOrderFacad orderFacad)
        {
            _financesFacad = financesFacad;
            _cartService = cartService;
            _cookieManager = new CookieManager();
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
            _orderFacad = orderFacad;
        }
        public async Task<IActionResult> Index()
        {
            var userId = ClaimsUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookieManager.GetBrowserId(HttpContext), userId);
            if (cart.Data.SumAmount > 0)
            {
                var requestPay = _financesFacad.addRequestPayService.Execute(cart.Data.SumAmount, userId.Value);

                // ارسال به درگاه پرداخت
                var result = await _payment.Request(new DtoRequest()
                {
                    Mobile = requestPay.Data.UserMobile,
                    CallbackUrl = $"https://localhost:44380/Pay/Verify?guid={requestPay.Data.GUId}",
                    Description = "پرداخت فاکتور شماره : " + requestPay.Data.RequestPayId,
                    Email = requestPay.Data.UserEmail,
                    Amount = requestPay.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                }, ZarinPal.Class.Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }
        }

        public async Task<IActionResult> Verify(Guid guid, string authority, string status)
        {
            if (status == "OK")
            {
                var requestPay = _financesFacad.getRequestPayService.Execute(guid);
                var verification = await _payment.Verification(new DtoVerification
                {
                    Amount = requestPay.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                    Authority = authority
                }, Payment.Mode.sandbox);

                if (verification.Status == 100)
                {
                    var userId = ClaimsUtility.GetUserId(User);
                    var cart = _cartService.GetMyCart(_cookieManager.GetBrowserId(HttpContext), userId);
                    _orderFacad.addNewOrderService.Execute(new AddNewOrderRequestDto
                    {
                        CartId = cart.Data.CartId,
                        RequestPayId = requestPay.Data.Id,
                        UserId = userId.Value
                    });
                    return RedirectToAction("Index", "Orders");
                }
                else
                {
                    return RedirectToAction("Index", "Cart");
                }
            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }
        }
    }
}
