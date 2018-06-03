using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class Area
    {
        public Area()
        {
            Consignee = new HashSet<Consignee>();
        }

        public int Id { get; set; }
        public int TheArea { get; set; }
        public string Aname { get; set; }
        public int TheCity { get; set; }

        public City TheCityNavigation { get; set; }
        public ICollection<Consignee> Consignee { get; set; }
    }
}
