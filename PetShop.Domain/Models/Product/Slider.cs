using PetShop.Domain.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Domain.Models
{
    public class Slider : BaseEntity
    {
        [Display(Name = "نام")]
        public string? Name { get; set; }

        [Display(Name = "بنراسلایدر")]
        public string? ImageName { get; set; }

        [Display(Name = "لینک")]
        public string Url { get; set; }

        [Display(Name = "از تاریخ:")]
        public DateTime FromDate { get; set; }

        [Display(Name = "تا تاریخ: ")]
        public DateTime? ToDate { get; set; }
    }
}