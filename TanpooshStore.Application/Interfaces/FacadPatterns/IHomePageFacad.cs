using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.HomePages.AddNewSlider;
using TanpooshStore.Application.Services.HomePages.GetSlider;

namespace TanpooshStore.Application.Interfaces.FacadPatterns
{
    public interface IHomePageFacad
    {
        AddnewSliderService addNewSliderService { get; }
        GetSliderService getSliderService { get; }
    }
}
