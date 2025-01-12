using Microsoft.AspNetCore.Mvc;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Components
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly PetShopContext _context;

        public SliderViewComponent(PetShopContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Slider = _context.Slider.Where(s => (s.FromDate <= DateTime.Now && (s.ToDate >= DateTime.Now || s.ToDate.ToString() == null) && !s.IsDeleted)).ToList();

            return View(Slider);
        }
    }
}