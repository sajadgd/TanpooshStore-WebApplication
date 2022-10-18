using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Order.Commands.AddNewOrder;
using TanpooshStore.Application.Services.Order.Commands.ChangeOrderState;
using TanpooshStore.Application.Services.Order.Queries.GetAdminOrder;
using TanpooshStore.Application.Services.Order.Queries.GetUserOrder;

namespace TanpooshStore.Application.Services.Order.FacadPattern
{
    public class OrderFacad : IOrderFacad
    {
        private readonly IDatabaseContext _context;
        public OrderFacad(IDatabaseContext context)
        {
            _context = context;
        }

        private readonly AddNewOrderService _addNewOrderService;
        public AddNewOrderService addNewOrderService
        {
            get { return _addNewOrderService ?? new AddNewOrderService(_context); }
        }

        private readonly GetUserOrderService _getUserOrderService;
        public GetUserOrderService getUserOrderService 
        {
            get { return _getUserOrderService ?? new GetUserOrderService(_context); }
        }

        private readonly GetAdminOrderService _getAdminOrderService;
        public GetAdminOrderService getAdminOrderService
        {
            get { return _getAdminOrderService ?? new GetAdminOrderService(_context); }
        }

        private readonly ChangeOrderStateService _changeOrderStateService;
        public ChangeOrderStateService changeOrderStateService
        {
            get { return _changeOrderStateService ?? new ChangeOrderStateService(_context); }
        }
    }
}
