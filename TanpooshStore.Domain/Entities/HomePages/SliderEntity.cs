using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Commons;

namespace TanpooshStore.Domain.Entities.HomePages
{
    public class SliderEntity: BaseEntity
    {
        public string Src { get; set; }
        public string Link { get; set; }
    }
}
