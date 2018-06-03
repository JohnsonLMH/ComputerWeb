using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Payment = new HashSet<Payment>();
        }

        public string TypeName { get; set; }
        public string Purl { get; set; }
        public string MethodName { get; set; }
        public string SmallImg { get; set; }
        public string BigImg { get; set; }

        public ICollection<Payment> Payment { get; set; }
    }
}
