using Microsoft.AspNetCore.Mvc;
using TanpooshStore.Application.Services.Common.Queries.GetMenuItem;

namespace EndPoint.Site.ViewComponents
{
    public class GetMenu: ViewComponent
    {
        private readonly IGetMenuItemService _getMenuItemService;
        public GetMenu(IGetMenuItemService getMenuItemService)
        {
            _getMenuItemService = getMenuItemService;
        }

        public IViewComponentResult Invoke()
        {
            var model = _getMenuItemService.Execute().Data;
            return View(viewName: "GetMenu", model);
        }
    }
}
