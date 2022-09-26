using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Order.Commands.AddNewOrder;
using TanpooshStore.Application.Services.Order.Queries.GetUserOrder;

namespace TanpooshStore.Application.Interfaces.FacadPatterns
{
    public interface IOrderFacad
    {
        AddNewOrderService addNewOrderService { get; }
        GetUserOrderService getUserOrderService { get; }
    }
}
