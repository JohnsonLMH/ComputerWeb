using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class ProductClass
    {
        public int ObjId { get; set; }
        public int TheProductId { get; set; }
        public int TheProductType { get; set; }

        public Product TheProduct { get; set; }
        public ProductType TheProductTypeNavigation { get; set; }
    }
}
