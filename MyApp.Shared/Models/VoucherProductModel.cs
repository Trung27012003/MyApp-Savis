using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.Models
{
    public class VoucherProductModel
    {
        public Guid Id { get; set; }
        public Guid VoucherId { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("VoucherId")]
        public VoucherModel? Voucher { get; set; }

        [ForeignKey("ProductId")]
        public ProductModel? Products { get; set; }
    }
}
