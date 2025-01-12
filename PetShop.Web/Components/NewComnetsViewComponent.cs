using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Components
{
    public class NewComnetsViewComponent(PetShopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var fourLastComments = context.Comment.Include(c => c.User).OrderByDescending(c => c.CreateDate).
                Take(4).ToList();
            return View(fourLastComments);
        }
    }
}