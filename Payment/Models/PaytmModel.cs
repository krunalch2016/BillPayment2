using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class PaytmModel
    {
        public string LPGNumber { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }
        public string amount { get; set; }
    }
}