using Microsoft.AspNetCore.Mvc;
using PetShop.Domain.ViewModels;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly PetShopContext _context;

        public CategoryViewComponent(PetShopContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var group = _context.Group.Where(g => g.IsDeleted.ToString().ToLower() == "false" && g.ShowHomeSite).Select(g => new ShowGroupViewModel()
            {
                GroupId = g.Id,
                Title = g.Title
            }).ToList();
            return View(group);
        }
    }
}