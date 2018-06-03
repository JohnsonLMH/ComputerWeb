using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class ComputerOrder
    {
        public int ObjId { get; set; }
        public int TheOrder { get; set; }
        public int UserId { get; set; }
        public DateTime OrderTime { get; set; }
        public int TheProductId { get; set; }
        public double Amt { get; set; }
        public int ThePayment { get; set; }
        public string OrderState { get; set; }

        public CustomerWords TheOrderNavigation { get; set; }
        public Payment ThePaymentNavigation { get; set; }
        public Product TheProduct { get; set; }
        public Customer User { get; set; }
    }
}
