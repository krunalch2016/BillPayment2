using Payment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Models
{
    public class PaymentModel
    {
        public long CardNumber { get; set; }
        public int CVVNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string AccountHolderName { get; set; }
        public string BankName { get; set; }
        public string UserID { get; set; }
        public int UserPassword { get; set; }
        public double Balance { get; set; }
        public float Amount { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public PaymentModel paymentobj { get; set; }
        public List<PaymentModel> paymentlist { get; set; }
    }
}