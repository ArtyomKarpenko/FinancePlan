//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinancePlan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbCapitals
    {
        public int CapitalId { get; set; }
        public int UserId { get; set; }
        public int MethodId { get; set; }
        public Nullable<decimal> FullAmount { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public int CurrencyId { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<System.DateTime> DateBegin { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
    }
}
