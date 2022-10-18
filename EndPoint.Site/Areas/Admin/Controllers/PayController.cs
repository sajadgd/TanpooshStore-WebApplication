using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TanpooshStore.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class PayController : Controller
    {
        private readonly IFinancesFacad _financesFacad;
        public PayController(IFinancesFacad financesFacad)
        {
            _financesFacad = financesFacad;
        }
        public IActionResult Index(int page=1, int pageSize=10)
        {
            var model = _financesFacad.getAdminRequestPayService.Execute(page, pageSize).Data;
            return View(model);
        }
    }
}
