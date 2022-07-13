using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Products.Commands.EditCategory
{
    public class EditCategoryRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
