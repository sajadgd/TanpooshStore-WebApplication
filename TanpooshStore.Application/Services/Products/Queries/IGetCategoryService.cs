﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Products.Queries.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Queries
{
    public interface IGetCategoryService
    {
        ResultDto<List<CategoriesDto>> Execute(int? parentId);
    }
}
