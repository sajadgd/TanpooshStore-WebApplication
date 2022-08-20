using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.HomePages.AddNewSlider;
using TanpooshStore.Application.Services.HomePages.GetSlider;

namespace TanpooshStore.Application.Services.HomePages.FacadPattern
{
    public class HomePageFacad : IHomePageFacad
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;
        public HomePageFacad(IDatabaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private readonly AddnewSliderService _addnewSliderService;
        public AddnewSliderService addNewSliderService
        {
            get { return _addnewSliderService ?? new AddnewSliderService(_context, _environment); }
        }

        private readonly GetSliderService _getSliderService;
        public GetSliderService getSliderService
        {
            get { return _getSliderService ?? new GetSliderService(_context); }
        }
    }
}
