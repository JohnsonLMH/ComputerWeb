using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF1
{
    public partial class Product
    {
        public Product()
        {
            ComputerOrder = new HashSet<ComputerOrder>();
            Evaluate = new HashSet<Evaluate>();
            Favorites = new HashSet<Favorites>();
            PriceList = new HashSet<PriceList>();
            ProductClass = new HashSet<ProductClass>();
            ShoppingCart = new HashSet<ShoppingCart>();
        }

        public int ObjId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public string SmallImg { get; set; }
        public string BigImg { get; set; }
        public string ProductState { get; set; }
        public DateTime Timetommarket { get; set; }
        public string Cpu { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }

        public ICollection<ComputerOrder> ComputerOrder { get; set; }
        public ICollection<Evaluate> Evaluate { get; set; }
        public ICollection<Favorites> Favorites { get; set; }
        public ICollection<PriceList> PriceList { get; set; }
        public ICollection<ProductClass> ProductClass { get; set; }
        public ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
