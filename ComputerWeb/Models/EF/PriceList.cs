using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF
{
    public partial class PriceList
    {
        public int ObjId { get; set; }
        public int ProductId { get; set; }
        public int TheCustomerType { get; set; }
        public decimal? RealPrice { get; set; }

        public Product Product { get; set; }
        public CustomerType TheCustomerTypeNavigation { get; set; }
    }
}
