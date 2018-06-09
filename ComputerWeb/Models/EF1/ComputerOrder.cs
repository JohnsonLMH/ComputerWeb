using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF1
{
    public partial class ComputerOrder
    {
        public ComputerOrder()
        {
            CustomerWords = new HashSet<CustomerWords>();
        }

        public int ObjId { get; set; }
        public int TheOrder { get; set; }
        public int UserId { get; set; }
        public DateTime OrderTime { get; set; }
        public int ProductId { get; set; }
        public double Amt { get; set; }
        public int ThePayment { get; set; }
        public string OrderState { get; set; }
        public string EvaluateState { get; set; }

        public Product Product { get; set; }
        public Payment ThePaymentNavigation { get; set; }
        public Customer User { get; set; }
        public ICollection<CustomerWords> CustomerWords { get; set; }
    }
}
