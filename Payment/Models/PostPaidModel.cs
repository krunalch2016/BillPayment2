using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class PostPaidModel
    {
        public long? MobileNumber { get; set; }
        public string Operator { get; set; }

        public List<PostPaidModel> list { get; set; }
    }
}