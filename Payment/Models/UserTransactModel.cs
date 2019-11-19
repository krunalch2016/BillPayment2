using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class UserTransactModel
    {
        public string CustomerName { get; set; }
        public long? MobileNumber { get; set; }
        public string Operator { get; set; }
        public string PlanType { get; set; }
        public decimal Amount { get; set; }
        public List<UserTransactModel> list { get; set; }
    }
}