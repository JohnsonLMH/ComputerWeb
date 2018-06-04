using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF
{
    public partial class Payment
    {
        public Payment()
        {
            ComputerOrder = new HashSet<ComputerOrder>();
        }

        public int ObjId { get; set; }
        public double Amount { get; set; }
        public int ThePayment { get; set; }
        public string AccountNo { get; set; }
        public DateTime TransTime { get; set; }
        public int TransNo { get; set; }

        public PaymentType ThePaymentNavigation { get; set; }
        public ICollection<ComputerOrder> ComputerOrder { get; set; }
    }
}
