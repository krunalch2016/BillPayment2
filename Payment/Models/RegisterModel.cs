using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class RegisterModel
    {
        public string CustomerName { get; set; }
        public long MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string Plantype { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string Operator { get; set; }
        public static long MobileNum { get; set; } 
    }
}