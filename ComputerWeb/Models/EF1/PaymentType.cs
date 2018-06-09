using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF1
{
    public partial class PaymentType
    {
        public int ObjId { get; set; }
        public string TypeName { get; set; }
        public string Purl { get; set; }
        public string MethodName { get; set; }
        public string SmallImg { get; set; }
        public string BigImg { get; set; }
        public int ThePayment { get; set; }

        public Payment Payment { get; set; }
    }
}
