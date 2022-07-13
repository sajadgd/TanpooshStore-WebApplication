using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Users.Commands.UserRegister.Dto;
using TanpooshStore.Common.Utilities;

namespace TanpooshStore.Application
{
    public class RegisterRequestValidator: AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FullName).NotNull().WithMessage(string.Format(ErrorMessage.RequierdMsg, "نام و نام خانوادگی"));
            RuleFor(x => x.Email).NotNull().WithMessage(string.Format(ErrorMessage.RequierdMsg, "ایمیل"));
            RuleFor(x => x.Password).NotNull().WithMessage(string.Format(ErrorMessage.RequierdMsg, "گذرواژه"));
            RuleFor(x => x.RePassword).NotNull().WithMessage(string.Format(ErrorMessage.RequierdMsg, "تکرار گذرواژه"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(string.Format(ErrorMessage.RegExpMsg, "ایمیل"));
            RuleFor(x => x.Password).Length(6, 30).WithMessage(string.Format(ErrorMessage.StringLength, "گذرواژه"));
            RuleFor(x => x.RePassword).Equal(y => y.Password).WithMessage(string.Format(ErrorMessage.Compare, "گذرواژه"));
        }
    }
}
