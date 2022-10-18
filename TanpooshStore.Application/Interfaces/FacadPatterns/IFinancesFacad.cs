using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Finances.Commands.AddRequestPay;
using TanpooshStore.Application.Services.Finances.Queries.GetAdminRequestPay;
using TanpooshStore.Application.Services.Finances.Queries.GetRequsetPay;

namespace TanpooshStore.Application.Interfaces.FacadPatterns
{
    public interface IFinancesFacad
    {
        AddRequestPayService addRequestPayService { get; }
        GetRequestPayService getRequestPayService { get; }
        GetAdminRequestPayService getAdminRequestPayService { get; }
    }
}
