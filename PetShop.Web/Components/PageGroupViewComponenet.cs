using Microsoft.AspNetCore.Mvc;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Components
{
    public class PageGroupViewComponenet : ViewComponent
    {
        private readonly PetShopContext _context;

        public PageGroupViewComponenet(PetShopContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}