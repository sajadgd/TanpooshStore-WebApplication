using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Common.Utilities;

namespace TanpooshStore.Application.Services.Users.Commands.UserRegister.Dto
{
    public class RegisterRequestDto
    {
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "گذرواژه")]
        public string Password { get; set; }

        [Display(Name = "تکرار گذرواژه")]
        public string RePassword { get; set; }

        public List<RolesInRegisterUserDto> Roles { get; set; }
    }
}
