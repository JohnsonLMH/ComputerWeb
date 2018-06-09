using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF1
{
    public partial class ShoppingCart
    {
        public int ObjId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Num { get; set; }

        public Product Product { get; set; }
        public Customer User { get; set; }
    }
}
