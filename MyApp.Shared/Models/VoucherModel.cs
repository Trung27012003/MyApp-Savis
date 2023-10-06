using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.Models
{
    public class VoucherModel
    {
        public Guid Id { get; set; }
        public Guid? VoucherTypeId { get; set; }
        public Guid? VoucherStatusId { get; set; }
        public string? Code { get; set; }
        public int? Quantity { get; set; }
        public int? Value { get; set; }
        public int? Minimum_order_value { get; set; }
        public DateTime? Create_Date { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }

        [ForeignKey("VoucherTypeId")]
        public VoucherTypeModel? VoucherType { get; set; }
        [ForeignKey("VoucherStatusId")]
        public VoucherStatusModel? VoucherStatus { get; set; }

        public virtual List<OrderModel>? Orders { get; set; }
    }
}
