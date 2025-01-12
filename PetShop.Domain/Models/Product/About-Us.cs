using System.ComponentModel.DataAnnotations;

namespace PetShop.Domain.Models
{
    public class About_Us
    {
        public int Id { get; set; }

        [Display(Name = "توضیح کوتاه")]
        [MaxLength(60, ErrorMessage = "تعداد کاراکتر بیش از حد مجاز")]
        public string? Title { get; set; }

        [Display(Name = "متن")]
        public string? Text { get; set; }
    }
}