using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Common.Queries.GetMenuItem.Dto
{
    public class GetMenuItemDto
    {
        public int CateId { get; set; }
        public string Name { get; set; }
        public List<GetMenuItemDto> Child { get; set; }
    }
}
