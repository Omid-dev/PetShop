using Microsoft.AspNetCore.Mvc;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Components
{
    public class NewProductsViewComponent : ViewComponent
    {
        private readonly PetShopContext _context;

        public NewProductsViewComponent(PetShopContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var fourProduct = _context.Product.Where(p => p.IsDeleted == false).OrderByDescending(g => g.CreateDate).Take(4).ToList();
            return View(fourProduct);
        }
    }
}