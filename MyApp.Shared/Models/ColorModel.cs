using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.Models
{
    public class ColorModel
    {
        [Key]
        public Guid ColorId { get; set; }
        public string? ColorName { get; set; }
        public string? ColorCode { get; set; }
        public virtual List<ProductDetailModel>? ProductDetails { get; set; }
    }
}
