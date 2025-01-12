using PetShop.Domain.Models.BaseEntities;
using PetShop.Domain.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Domain.Models.Orders
{
    public class OrderDetail : BaseEntity
    {
        #region Properties

        public int OrderId { get; set; }
        public int ProdcutId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        #endregion Properties

        #region Navigation

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [ForeignKey("ProdcutId")]
        public Product Product { get; set; }

        #endregion Navigation
    }
}