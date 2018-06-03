using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class Product
    {
        public Product()
        {
            ComputerOrder = new HashSet<ComputerOrder>();
            ProductClass = new HashSet<ProductClass>();
        }

        public int TheProductId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public string SmallImg { get; set; }
        public string BigImg { get; set; }
        public string ProductState { get; set; }
        public DateTime Timetommarket { get; set; }
        public string Productpositioning { get; set; }
        public string Cpu { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public string Screensize { get; set; }

        public PriceList PriceList { get; set; }
        public ICollection<ComputerOrder> ComputerOrder { get; set; }
        public ICollection<ProductClass> ProductClass { get; set; }
    }
}
