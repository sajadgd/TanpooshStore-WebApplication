using Microsoft.AspNetCore.Mvc;
using TanpooshStore.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.ViewComponents
{
    public class ProductModal : ViewComponent
    {
        private readonly IProductFacad _productFacad;
        public ProductModal(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IViewComponentResult Invoke(int productId)
        {
            var model = _productFacad.getSiteProductDetailService.Execute(productId).Data;
            return View(viewName: "ProductModal", model);
        }
    }
}
