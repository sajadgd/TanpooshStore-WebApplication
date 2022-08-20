using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Products.Queries.Dto;
using TanpooshStore.Application.Services.Products.Queries.GetSiteProductService;

namespace EndPoint.Site.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(int page = 1, int pageSize = 10, int? cateId = null, int? pCateId = null, string searchKey= "", GetSiteProductOrdering ordering = GetSiteProductOrdering.NotOrdered)
        {
            var model = _productFacad.getSiteProductService.Execute(new GetSiteProductRequestDto
            {
                CateId = cateId,
                Page = page,
                PageSize = pageSize,
                SearchKey = searchKey,
                Ordering = ordering,
                ParentCateId = pCateId
            }).Data;
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
