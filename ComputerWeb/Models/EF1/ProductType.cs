using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF1
{
    public partial class ProductType
    {
        public ProductType()
        {
            ProductClass = new HashSet<ProductClass>();
        }

        public int ObjId { get; set; }
        public string ClassifyType { get; set; }
        public string TypeName { get; set; }
        public int TheProductType { get; set; }

        public ICollection<ProductClass> ProductClass { get; set; }
    }
}
