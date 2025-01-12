using System.ComponentModel.DataAnnotations;

namespace PetShop.Domain.Models.BaseEntities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "تاریخ ویرایش")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "حذف شده است؟")]
        public bool IsDeleted { get; set; }
    }
}