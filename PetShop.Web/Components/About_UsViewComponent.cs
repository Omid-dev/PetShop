using Microsoft.AspNetCore.Mvc;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Components
{
    public class About_UsViewComponent(PetShopContext context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Aobout_us = context.About_Us.First();
            return View(Aobout_us);
        }
    }
}