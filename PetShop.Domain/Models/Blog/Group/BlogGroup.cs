using PetShop.Domain.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Domain.Models.Blog.Group
{
    public class BlogGroup : BaseEntity
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "توضیح مختصر")]
        public string Description { get; set; }

        #region Nvavigation

        public ICollection<Blog>? Blogs { get; set; }

        #endregion Nvavigation
    }
}