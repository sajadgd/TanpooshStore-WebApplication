using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Finances.Commands.AddRequestPay;
using TanpooshStore.Application.Services.Finances.Queries.GetAdminRequestPay;
using TanpooshStore.Application.Services.Finances.Queries.GetRequsetPay;

namespace TanpooshStore.Application.Services.Finances.FacadPattern
{
    public class FinancesFacad : IFinancesFacad
    {
        private readonly IDatabaseContext _context;
        public FinancesFacad(IDatabaseContext context)
        {
            _context = context;
        }

        private readonly AddRequestPayService _addRequestPayService;
        public AddRequestPayService addRequestPayService
        {
            get { return _addRequestPayService ?? new AddRequestPayService(_context); }
        }

        private readonly GetRequestPayService _getRequestPayService;
        public GetRequestPayService getRequestPayService
        {
            get { return _getRequestPayService ?? new GetRequestPayService(_context); }
        }

        private readonly GetAdminRequestPayService _getAdminRequestPayService;
        public GetAdminRequestPayService getAdminRequestPayService
        {
            get { return _getAdminRequestPayService ?? new GetAdminRequestPayService(_context); }
        }
    }
}
