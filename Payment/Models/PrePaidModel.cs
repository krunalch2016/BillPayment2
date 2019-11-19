using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class PrePaidModel
    {
        public string Operator { get; set; }
        public double MRP { get; set; }
        public string ValidateDays { get; set; }
        public string Descriptions { get; set; }
        public string Roaming { get; set; }
        public string SMS { get; set; }
        public string DataSpeed { get; set; }
        public long MobileNumber { get; set; }

        public List<PrePaidModel> PrepaidList;
    }
}