using EndPoint.Site.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Products.Commands.EditCategory;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IProductFacad _productFacad;
        public CategoryController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(int? parentId)
        {
            CategoriesViewModel model = new CategoriesViewModel();
            var result = _productFacad.GetCategoryService.Execute(parentId).Data;
            model.ListCategories = result;
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewCategory(int? parentId)
        {
            ViewBag.ParentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(int? parentId, string name)
        {
            var result = _productFacad.AddNewCategoryService.Execute(parentId, name);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Edit(int categoryId, string name)
        {
            var result = _productFacad.editCategoryService.Execute(new EditCategoryRequestDto
            {
                Id = categoryId,
                Name = name
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(int categoryId)
        {
            var result = _productFacad.removeCategoryService.Execute(categoryId);
            return Json(result);
        }
    }
}
