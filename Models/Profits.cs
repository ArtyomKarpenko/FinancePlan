using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancePlan.Models
{
    public class Profits
    {
        public int ProfitId { get; set; }
        public int UserId { get; set; }
        public int MethodId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int Currency { get; set; }

    }
}