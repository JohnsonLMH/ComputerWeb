using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class CustomerType
    {
        public CustomerType()
        {
            Customer = new HashSet<Customer>();
            PriceList = new HashSet<PriceList>();
        }

        public string Typename { get; set; }
        public double MinSpending { get; set; }
        public int TheCustomerType { get; set; }

        public ICollection<Customer> Customer { get; set; }
        public ICollection<PriceList> PriceList { get; set; }
    }
}
