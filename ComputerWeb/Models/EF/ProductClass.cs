using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF
{
    public partial class ProductClass
    {
        public int ObjId { get; set; }
        public int ProductId { get; set; }
        public int TheProductType { get; set; }

        public Product Product { get; set; }
        public ProductType TheProductTypeNavigation { get; set; }
    }
}
