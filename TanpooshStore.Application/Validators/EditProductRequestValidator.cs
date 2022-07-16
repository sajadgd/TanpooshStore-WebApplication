using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Products.Commands.EditProduct;
using TanpooshStore.Common.Utilities;

namespace TanpooshStore.Application.Validators
{
    public class EditProductRequestValidator : AbstractValidator<EditProductRequestDto>
    {
        public EditProductRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(string.Format(ErrorMessage.RequierdMsg, "نام محصول"));
            RuleFor(x => x.Price).NotNull().WithMessage(string.Format(ErrorMessage.RequierdMsg, "قیمت محصول"));
            RuleFor(x => x.Brand).NotNull().WithMessage(string.Format(ErrorMessage.RequierdMsg, "برند محصول"));
            RuleFor(x => x.Invertory).NotNull().WithMessage(string.Format(ErrorMessage.RequierdMsg, "موجودی انبار محصول"));
        }
    }
}
