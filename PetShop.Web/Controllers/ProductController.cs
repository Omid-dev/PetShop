using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Services.Impelemntaions;
using PetShop.Application.Services.Interfaces;
using PetShop.Application.Utility;

namespace PetShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IGroupsServices _groupsServices;

        public ProductController(IProductServices productServices, IGroupsServices groupsServices)
        {
            this._productServices = productServices;
            this._groupsServices = groupsServices;
        }

        public IActionResult Index(int page = 1)
        {
            var products = _productServices.GetAll();
            double pagecount;
            var res = Utilities.pagging(products, page, out pagecount, 3);
            ViewBag.pageCount = pagecount;
            ViewBag.pageid = page;
            ViewBag.Title = "محصولات";
            return View(res);
        }

        public IActionResult GroupProdcuts(int groupId, int page = 1)
        {
            var product = _productServices.GetbyGroupId(groupId);
            double pagecount;
            var res = Utilities.pagging(product, page, out pagecount, 3);
            ViewBag.Title = "دسته بندی";

            ViewBag.pageCount = pagecount;
            ViewBag.pageid = page;
            ViewBag.groupId = groupId;
            ViewBag.Groups = _groupsServices.GettAll().FirstOrDefault(g => g.Id == groupId)?.Title;
            return View(res);
        }

        public IActionResult Deteail(int id)
        {
            var products = _productServices.GetPopular(5);
            ViewBag.Papulars1 = products.Take(1).SingleOrDefault();
            ViewBag.Papulars2 = products.Skip(1).Take(1).SingleOrDefault();
            ViewBag.Papulars3 = products.Skip(2).Take(1).SingleOrDefault();
            var product = _productServices.GetById(id);
            product.Visited++;
            _productServices.Save();
            return View(product);
        }
    }
}