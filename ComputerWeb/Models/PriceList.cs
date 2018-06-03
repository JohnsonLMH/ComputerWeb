using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class PriceList
    {
        public int TheProductId { get; set; }
        public int TheCustomerType { get; set; }
        public decimal? RealPrice { get; set; }

        public CustomerType TheCustomerTypeNavigation { get; set; }
        public Product TheProduct { get; set; }
    }
}
