using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Users.Qureies.Dto
{
    public class GetUserRequestDto
    {
        public string SearchKey { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
