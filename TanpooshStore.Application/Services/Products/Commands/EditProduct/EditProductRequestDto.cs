using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Products.Queries.Dto;

namespace TanpooshStore.Application.Services.Products.Commands.EditProduct
{
    public class EditProductRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Invertory { get; set; }
        public bool Displayed { get; set; }
        public int CategoryId { get; set; }
    }
}
