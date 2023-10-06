using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.Models
{
    public class UserVoucherModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid VoucherId { get; set; }
        public bool? Status { get; set; }
        [ForeignKey("UserId")]
        public UserModel? User { get; set; }
        [ForeignKey("VoucherId")]
        public VoucherModel? Voucher { get; set; }
    }
}
