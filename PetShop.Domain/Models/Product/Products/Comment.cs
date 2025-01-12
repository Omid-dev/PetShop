using PetShop.Domain.Models.BaseEntities;
using PetShop.Domain.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Domain.Models.Products
{
    public class Comment : BaseEntity
    {
        #region Properties

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Text { get; set; }

        #endregion Properties

        #region Navigaition

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        #endregion Navigaition
    }
}