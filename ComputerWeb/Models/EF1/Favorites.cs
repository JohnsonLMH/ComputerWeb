using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF1
{
    public partial class Favorites
    {
        public int ObjId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }

        public Product Product { get; set; }
        public Customer User { get; set; }
    }
}
