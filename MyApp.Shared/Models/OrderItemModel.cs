using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.Models
{
    public class OrderItemModel
    {
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ProductDetailId { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }

        [ForeignKey("OrderId")]
        public OrderModel? Order { get; set; }
        [ForeignKey("ProductDetailId")]
        public ProductDetailModel? ProductDetail { get; set; }
    }
}
