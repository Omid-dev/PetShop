using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Components
{
    public class NewBlogsViewComponent(PetShopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lastBlogs = context.Blog.Include(b => b.BlogGroup).OrderByDescending(b => b.CreateDate).
                Take(4).ToList();
            return View(lastBlogs);
        }
    }
}