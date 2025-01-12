using System.ComponentModel.DataAnnotations;

namespace PetShop.Domain.ViewModels
{
    public class ShowProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام محصول")]
        public string Name { get; set; }

        [Display(Name = "تعداد محصول")]
        public int? Stock { get; set; }

        [Display(Name = "گروه")]
        public int GroupId { get; set; }

        [Display(Name = "عکس محصول")]
        public string ImageName { get; set; } = "nophoto.jpg";

        [Display(Name = "قیمت")]
        public int Price { get; set; } = 0;
    }
}