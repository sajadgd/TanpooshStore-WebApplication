﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Carts.Dto
{
    public class CartDto
    {
        public List<CartItemDto> CartItems { get; set; }
        public int SumAmount { get; set; }
        public int ProductCount { get; set; }
        public int CartId { get; set; }
    }
}
