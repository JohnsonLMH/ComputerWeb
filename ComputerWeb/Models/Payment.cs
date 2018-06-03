using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class Payment
    {
        public Payment()
        {
            ComputerOrder = new HashSet<ComputerOrder>();
        }

        public double Amount { get; set; }
        public string TypeName { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public DateTime TransTime { get; set; }
        public int TransNo { get; set; }
        public int ThePayment { get; set; }

        public PaymentType TypeNameNavigation { get; set; }
        public ICollection<ComputerOrder> ComputerOrder { get; set; }
    }
}
