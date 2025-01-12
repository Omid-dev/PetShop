using Microsoft.AspNetCore.Mvc;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Components
{
    public class BlogGroupsViewComponents : ViewComponent
    {
        private readonly PetShopContext _context;

        public BlogGroupsViewComponents(PetShopContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var group = _context.BlogGroup.Where(b => !b.IsDeleted).ToList();
            return View(group);
        }
    }
}