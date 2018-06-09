using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF1
{
    public partial class CustomerWords
    {
        public int ObjId { get; set; }
        public int TheOrder { get; set; }
        public string Words { get; set; }

        public ComputerOrder TheOrderNavigation { get; set; }
    }
}
