using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Services.Interfaces;
using PetShop.Application.Utility;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Products;

namespace PetShop.Web.Controllers
{
    [Authorize]
    public class CommentController(IUserServices userServices,
        ICommentServices commentServices) : Controller
    {
        public async Task Add(int id, string text)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userIdLogin = User.GetUserId();
                var user = await userServices.GetByIdAsync(userIdLogin);
                Comment comment = new Comment()
                {
                    UserId = userIdLogin,
                    Text = text,
                    CreateDate = DateTime.Now,
                    Email = user?.Email,
                    ProductId = id,
                    Name = user?.Name,
                    IsDeleted = false,
                };

                await commentServices.Add(comment);
                await commentServices.SaveAsync();
            }
        }

        public async Task<PartialViewResult> ShowComment(int id)
        {
            var comment = await commentServices.GetByProductId(id);
            return PartialView(comment);
        }
    }
}