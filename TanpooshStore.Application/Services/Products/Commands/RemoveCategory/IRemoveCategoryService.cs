using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Commands.RemoveCategory
{
    public interface IRemoveCategoryService
    {
        ResultDto Execute(int Id);
    }
}
