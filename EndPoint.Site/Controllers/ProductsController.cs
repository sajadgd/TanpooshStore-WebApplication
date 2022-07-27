using Microsoft.AspNetCore.Mvc;
using TanpooshStore.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(int page=1, int pageSize=10)
        {
            var model = _productFacad.getSiteProductService.Execute(page, pageSize).Data;
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int productId)
        {
            var model = _productFacad.getSiteProductDetailService.Execute(productId).Data;
            return View(model);
        }
    }
}
