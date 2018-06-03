using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            ProductClass = new HashSet<ProductClass>();
        }

        public string ClassifyType { get; set; }
        public string TypeName { get; set; }
        public int TheProductType { get; set; }

        public ICollection<ProductClass> ProductClass { get; set; }
    }
}
