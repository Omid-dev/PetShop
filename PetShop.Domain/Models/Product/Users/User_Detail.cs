using PetShop.Domain.Models.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Domain.Models.Users
{
    public class User_Detail : BaseEntity
    {
        #region Properties

        public int UserId { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? ApartmentName { get; set; }
        public string? Zip_Code { get; set; }

        #endregion Properties

        #region Navigation

        [ForeignKey("UserId")]
        public User? User { get; set; }

        #endregion Navigation
    }
}