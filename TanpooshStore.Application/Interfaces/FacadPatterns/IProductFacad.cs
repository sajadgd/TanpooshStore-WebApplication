using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Products.Commands.AddNewCategory;
using TanpooshStore.Application.Services.Products.Commands.AddNewProduct;
using TanpooshStore.Application.Services.Products.Commands.EditCategory;
using TanpooshStore.Application.Services.Products.Commands.EditProduct;
using TanpooshStore.Application.Services.Products.Commands.RemoveCategory;
using TanpooshStore.Application.Services.Products.Commands.RemoveProduct;
using TanpooshStore.Application.Services.Products.Queries;
using TanpooshStore.Application.Services.Products.Queries.GetAdminProductDetailService;
using TanpooshStore.Application.Services.Products.Queries.GetAdminProductService;
using TanpooshStore.Application.Services.Products.Queries.GetAllCategories;
using TanpooshStore.Application.Services.Products.Queries.GetSiteProductDetailService;
using TanpooshStore.Application.Services.Products.Queries.GetSiteProductService;

namespace TanpooshStore.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        GetCategoryService GetCategoryService { get; }
        EditCategoryService editCategoryService { get; }
        RemoveCategoryService removeCategoryService { get; }
        GetAllCategoriesService getAllCategoriesService { get; }
        AddNewProductService addNewProductService { get; }
        RemoveProductService removeProductService { get; }
        EditProductService editProductService { get; }
        GetAdminProductDetailService getAdminProductDetailService { get; }
        GetSiteProductDetailService getSiteProductDetailService { get; }


        /// <summary>
        /// گرفتن لیست محصولات ادمین پنل
        /// </summary>
        GetAdminProductService getAdminProductService { get; }

        /// <summary>
        /// گرفتن لیست محصولات پنل کاربر
        /// </summary>
        GetSiteProductService getSiteProductService { get; }
    }
}
