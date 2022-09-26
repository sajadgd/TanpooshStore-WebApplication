using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Finances.Commands.AddRequestPay.Dto
{
    public class ResultRequestPayDto
    {
        public int RequestPayId { get; set; }
        public Guid GUId { get; set; }
        public int Amount { get; set; }
        public string UserEmail { get; set; }
        public string UserMobile { get; set; }
    }
}
