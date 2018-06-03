using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class Consignee
    {
        public int ObjId { get; set; }
        public string Cname { get; set; }
        public int TheArea { get; set; }
        public int UserId { get; set; }
        public string Fulladdress { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }

        public Area TheAreaNavigation { get; set; }
        public Customer User { get; set; }
    }
}
