using System.ComponentModel.DataAnnotations;

namespace PetShop.Domain.ViewModels
{
    public class DetailUserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(20)]
        public string Family { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        public int UserId { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string State { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string City { get; set; }

        [Display(Name = "خیابان")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string Street { get; set; }

        [Display(Name = "نام آپارتمان")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string ApartmentName { get; set; }

        [Display(Name = "کدپستی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string Zip_Code { get; set; }

        public int IdDetail { get; set; }

        public int IdUser { get; set; }
    }
}