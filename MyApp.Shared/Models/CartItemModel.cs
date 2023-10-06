using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.Models
{
    public class CartItemModel
    {
        public Guid Id { get; set; }
        public Guid? CartId { get; set; }
        public Guid? ProductDetail_ID { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        [ForeignKey("CartId")]
        public CartModel Cart { get; set; }
        [ForeignKey("ProductDetail_ID")]
        public ProductDetailModel ProductDetail { get; set; }
    }
}
