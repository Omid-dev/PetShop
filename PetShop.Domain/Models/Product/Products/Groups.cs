using PetShop.Domain.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Domain.Models.Products
{
    public class Groups : BaseEntity
    {
        #region Properties

        [Display(Name = "نمایش صفحه اصلی سایت")]
        public bool ShowHomeSite { get; set; } = false;

        [Display(Name = "توسط")]
        public int? UserIdOwner { get; set; }

        [ForeignKey("UserOwner")]
        public Users.User? User { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "توضیح")]
        public string? Description { get; set; }

        public ICollection<Product>? Products { get; set; }

        #endregion Properties
    }
}