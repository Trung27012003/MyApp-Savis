using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.Models
{
    public class UserModel : IdentityUser<Guid>
    {
        public DateTime? DateOfBirth { get; set; }
        public int? Points { get; set; }
        public string FullName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Address { get; set; }

    }
}
