using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF
{
    public partial class CustomerType
    {
        public CustomerType()
        {
            Customer = new HashSet<Customer>();
            PriceList = new HashSet<PriceList>();
        }

        public int ObjId { get; set; }
        public string Typename { get; set; }
        public int MinSpending { get; set; }
        public int TheCustomerType { get; set; }

        public ICollection<Customer> Customer { get; set; }
        public ICollection<PriceList> PriceList { get; set; }
    }
}
