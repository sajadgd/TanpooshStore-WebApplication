using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Common.Dto;
using TanpooshStore.Domain.Entities.Product;

namespace TanpooshStore.Application.Services.Products.Commands.AddNewCategory
{
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDatabaseContext _context;
        public AddNewCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int? parentId, string name)
        {
            if (string.IsNullOrWhiteSpace(name) == true)
            {
                var result1 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام دسته بندی را تعریف کنید !"
                };
                return result1;
            }
            CategoryEntity category = new CategoryEntity()
            {
                Name = name,
                ParentCategory = GetParent(parentId),
            };
            category.InsertTime = DateTime.Now;
            _context.Tbl_Category.Add(category);
            _context.SaveChanges();
            var result = new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی جدید اضافه شد !"
            };
            return result;
        }
        private CategoryEntity GetParent(int? parentId)
        {
            return _context.Tbl_Category.Find(parentId);
        }
    }
}
