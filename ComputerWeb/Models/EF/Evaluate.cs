using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF
{
    public partial class Evaluate
    {
        public int ObjId { get; set; }
        public int TheOrder { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }

        public Product Product { get; set; }
    }
}
