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
    
    public partial class tbProfit
    {
        public int ProfitId { get; set; }
        public int UserId { get; set; }
        public int MethodId { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime Date { get; set; }
        public int CurrencyId { get; set; }
    
        public virtual tbUsers tbUsers { get; set; }
    }
}
