﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.ViewModel
{
    public class UserViewModel
    {
        public DateTime? DateOfBirth { get; set; }
        public int? Points { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
