using PetShop.Domain.Models.BaseEntities;
using PetShop.Domain.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Domain.Models.Orders
{
    public class Order : BaseEntity
    {
        #region Properties

        public int UserId { get; set; }
        public bool IsFinally { get; set; }

        #endregion Properties

        #region Navigation

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }

        #endregion Navigation
    }
}