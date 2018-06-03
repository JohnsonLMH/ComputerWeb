using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class City
    {
        public City()
        {
            Area = new HashSet<Area>();
        }

        public int Id { get; set; }
        public int TheCity { get; set; }
        public string Cname { get; set; }
        public int TheProvince { get; set; }

        public Province TheProvinceNavigation { get; set; }
        public ICollection<Area> Area { get; set; }
    }
}
