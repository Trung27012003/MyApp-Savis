using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.Models
{
    public class ProductModel
    {
        [Key]
        public Guid Id { get; set;  
        public Guid? CategoryId { get; set; }
        public string? ProductName { get; set; }
        public int? AvailableQuantity { get; set; }
        public DateTime? Create_At { get; set; }
        public DateTime? Update_At { get; set; }
        public string? Description { get; set; }
        public string? Long_Description { get; set; }
        public bool? Status { get; set; }

        [ForeignKey("CategoryId")]
        public CategoryModel? Category { get; set; }


        public virtual List<ProductDetailModel>? ProductDetails { get; set; }
        public virtual List<VoucherProductModel>? VoucherProduct { get; set; }
    }
}
