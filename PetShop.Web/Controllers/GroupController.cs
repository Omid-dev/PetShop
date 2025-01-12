using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Services.Interfaces;

namespace PetShop.Web.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupsServices _repository;

        public GroupController(IGroupsServices repository)
        {
            this._repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}