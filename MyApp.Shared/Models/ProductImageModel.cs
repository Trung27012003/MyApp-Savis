using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.Models
{
    public class ProductImageModel
    {
        public Guid Id { get; set; }
        public Guid? ProductDetailId { get; set; }
        public string? ImageUrl { get; set; }

        [ForeignKey("ProductId")]
        public ProductDetailModel? ProductDetails { get; set; }
    }
}
