using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class LoginModel
    {
        public long MobileNumber { get; set; }
        public string ConfirmPassword { get; set; } 
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string NewPassword { get; set; }

        public List<LoginModel> list { get; set; }
    }
}