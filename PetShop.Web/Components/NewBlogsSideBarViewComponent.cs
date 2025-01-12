using Microsoft.AspNetCore.Mvc;
using PetShop.Domain.ViewModels;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Components
{
    public class NewBlogsSideBarViewComponent : ViewComponent
    {
        private readonly PetShopContext _context;

        public NewBlogsSideBarViewComponent(PetShopContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var LastFourBlog = _context.Blog.Where(b => !b.IsDeleted).
                OrderByDescending(b => b.CreateDate).Take(4)
                .Select(b => new ShowLastBlogViewModel()
                {
                    BlogId = b.Id,
                    CreateDate = b.CreateDate,
                    Title = b.Title,
                    ImageName = b.ImageName,
                }).ToList();

            return View(LastFourBlog);
        }
    }
}