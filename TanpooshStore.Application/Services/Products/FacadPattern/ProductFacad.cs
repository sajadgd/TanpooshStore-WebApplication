using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Interfaces.FacadPatterns;
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
using TanpooshStore.Application.Services.Products.Queries.GetSiteProductService;

namespace TanpooshStore.Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;
        public ProductFacad(IDatabaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        private readonly AddNewCategoryService _addNewCategoryService;
        public AddNewCategoryService AddNewCategoryService
        {
            get { return _addNewCategoryService ?? new AddNewCategoryService(_context); }
        }

        private readonly GetCategoryService _getCategoryService;
        public GetCategoryService GetCategoryService
        {
            get { return _getCategoryService ?? new GetCategoryService(_context); }
        }

        private readonly EditCategoryService _editCategoryService;
        public EditCategoryService editCategoryService
        {
            get { return _editCategoryService ?? new EditCategoryService(_context); }
        }

        private readonly RemoveCategoryService _removeCategoryService;
        public RemoveCategoryService removeCategoryService
        {
            get { return _removeCategoryService ?? new RemoveCategoryService(_context); }
        }

        private readonly AddNewProductService _addNewProductService;
        public AddNewProductService addNewProductService
        {
            get { return _addNewProductService ?? new AddNewProductService(_context, _environment); }
        }

        private readonly GetAllCategoriesService _getAllCategoriesService;
        public GetAllCategoriesService getAllCategoriesService
        {
            get { return _getAllCategoriesService ?? new GetAllCategoriesService(_context); }
        }

        private readonly GetAdminProductService _getAdminProductService;
        public GetAdminProductService getAdminProductService
        {
            get { return _getAdminProductService ?? new GetAdminProductService(_context); }
        }

        private readonly RemoveProductService _removeProductService;
        public RemoveProductService removeProductService
        {
            get { return _removeProductService ?? new RemoveProductService(_context); }
        }

        private readonly EditProductService _editProductService;
        public EditProductService editProductService
        {
            get { return _editProductService ?? new EditProductService(_context); }
        }

        private readonly GetAdminProductDetailService _getAdminProductDetailService;
        public GetAdminProductDetailService getAdminProductDetailService
        {
            get { return _getAdminProductDetailService ?? new GetAdminProductDetailService(_context); }
        }

        private readonly GetSiteProductService _getSiteProductService;
        public GetSiteProductService getSiteProductService
        {
            get { return _getSiteProductService ?? new GetSiteProductService(_context); }
        }
    }
}
