//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Payment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class debit_creditcard_table
    {
        public long CardNumber { get; set; }
        public Nullable<int> CVVNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string AccountHolderName { get; set; }
        public string BankName { get; set; }
        public string UserID { get; set; }
        public Nullable<int> UserPassword { get; set; }
        public Nullable<decimal> Balance { get; set; }
    }
}
