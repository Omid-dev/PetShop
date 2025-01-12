using PetShop.Domain.Models.BaseEntities;
using PetShop.Domain.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Domain.Models.Blog.Group
{
    public class Blog : BaseEntity
    {
        #region Properties

        [Display(Name = "گروه")]
        public int GroupId { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "توضیح مختصر")]
        public string ShortDescription { get; set; }

        [Display(Name = "متن")]
        public string Text { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; } = "nophoto";

        [Display(Name = "تعداد بازدید")]
        public int Seen { get; set; }

        [Display(Name = "توسط")]
        public int UserId { get; set; }

        #endregion Properties

        #region Navigation

        [ForeignKey("GroupId")]
        public BlogGroup? BlogGroup { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        #endregion Navigation
    }
}