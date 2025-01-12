using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Services.Interfaces;
using PetShop.Application.Utility;

namespace PetShop.Web.Controllers
{
    public class BlogController(IBlogServises blogServises, IBlogGroupServices blogGroupServices) : Controller
    {
        public async Task<IActionResult> Index(int page = 1)
        {
            var collection = await blogServises.GetAll();
            double pagecount;
            var res = Utilities.pagging(collection, page, out pagecount, 3);

            ViewBag.pageCount = pagecount;
            ViewBag.pageid = page;

            return View(res);
        }

        public async Task<IActionResult> BlogGroups(int groupId, int page = 1)
        {
            var Blog = await blogServises.GetByGroupId(groupId);
            double pagecount;
            var res = Utilities.pagging(Blog, page, out pagecount, 1);
            ViewBag.title = await blogGroupServices.GetTitle(groupId);
            ViewBag.pageCount = pagecount;
            ViewBag.pageid = page;
            ViewBag.groupId = groupId;
            return View(res);
        }

        public async Task<IActionResult> Details(int BlogId)
        {
            var Blog = await blogServises.GetById(BlogId);
            Blog.Seen++;
            await blogServises.SaveAsync();

            return View(Blog);
        }
    }
}