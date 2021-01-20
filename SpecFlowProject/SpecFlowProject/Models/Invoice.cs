using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject.Models
{
    public class Invoice
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime BillingMonth { get; set; }
        public decimal InternalRate { get; set; }
        public string Description { get; set; }         
        public string DevLineDescription { get; set; } 
        public decimal BillingRate { get; set; } 
        public decimal DevAmount { get; set; } 
        public string CreditDescription { get; set; } 
        public decimal CreditRate { get; set; } 
        public decimal NewCredit { get; set; } 
        public decimal CreditAmount { get; set; } 
        public string NonDevLineDes { get; set; }  
        public decimal NonDevAmount { get; set; } 
        public decimal USPaidAmount { get; set; }
        public decimal NonDevPaidAmount { get; set; } 
        public decimal USJiraTimeLoggedOverride { get; set; }
        public decimal UsWitheldHoursOverride { get; set; }
    }
}
