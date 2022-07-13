using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Users.Commands.UserLogin.Dto
{
    public class LoginResultDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Roles { get; set; }
    }
}
