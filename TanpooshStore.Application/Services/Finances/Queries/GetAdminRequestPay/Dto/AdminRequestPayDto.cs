using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Finances.Queries.GetAdminRequestPay.Dto
{
    public class AdminRequestPayDto
    {
        public int Id { get; set; }
        public Guid GUId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;
    }
}
