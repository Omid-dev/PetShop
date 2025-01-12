using PetShop.Domain.Models.BaseEntities;
using PetShop.Domain.Models.Orders;
using PetShop.Domain.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Domain.Models.Products
{
    public class Product : BaseEntity
    {
        [Display(Name = "نام محصول")]
        public string Name { get; set; }

        [Display(Name = "تعداد محصول")]
        public int? Stock { get; set; }

        [Display(Name = "توضیح مختصر")]
        public string? Desctiption { get; set; }

        [Display(Name = "گروه")]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        [Display(Name = "گروه")]
        public Groups? Groups { get; set; }

        [Display(Name = "توسط")]
        public int UserIdOwner { get; set; }

        [ForeignKey("UserIdOwner")]
        [Display(Name = "توسط")]
        public User? User { get; set; }

        [Display(Name = "عکس محصول")]
        public string ImageName { get; set; } = "nophoto.jpg";

        [Display(Name = "قیمت")]
        public int Price { get; set; } = 0;

        [Display(Name = "بازدید")]
        public int? Visited { get; set; } = 0;

        [Display(Name = "توضیحات")]
        public string? Text { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}