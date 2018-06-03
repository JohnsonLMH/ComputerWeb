using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class CustomerWords
    {
        public CustomerWords()
        {
            ComputerOrder = new HashSet<ComputerOrder>();
        }

        public int TheOrder { get; set; }
        public string Words { get; set; }

        public ICollection<ComputerOrder> ComputerOrder { get; set; }
    }
}
