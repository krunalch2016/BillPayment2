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
    
    public partial class User_Transaction
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public long MobileNumber { get; set; }
        public string PlantType { get; set; }
        public string Operator { get; set; }
        public decimal Amount { get; set; }
    
        public virtual table_Registration table_Registration { get; set; }
    }
}
