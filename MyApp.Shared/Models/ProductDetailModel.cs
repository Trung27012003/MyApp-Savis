using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.Models
{
    public class ProductDetailModel
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? ColorId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceSale { get; set; }
        public DateTime? Create_At { get; set; }
        public DateTime? Update_At { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }

        [ForeignKey("ProductId")]
        public ProductModel? Product { get; set; }
         [ForeignKey("ColorId")]
        public ColorModel? Colors { get; set; }


        public virtual List<CartItemModel>? CartItem { get; set; }
        public virtual List<OrderItemModel>? OrderItems { get; set; }
        public virtual List<ProductImageModel>? ProductImages { get; set; }
    }
}
