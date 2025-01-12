using PetShop.Domain.Models.BaseEntities;
using PetShop.Domain.Models.Orders;
using PetShop.Domain.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Domain.Models.Users
{
    public class User : BaseEntity
    {
        #region Properties

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(20)]
        public string Family { get; set; }

        [Display(Name = "موبایل")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [MaxLength(300)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string? Password { get; set; }

        [Display(Name = "ایا ادمین است؟")]
        public bool IsAdmin { get; set; } = false;

        #endregion Properties

        #region Navigation

        public ICollection<Groups>? Groups { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public User_Detail? User_Detail { get; set; }

        #endregion Navigation
    }
}