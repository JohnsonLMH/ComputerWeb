using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF1
{
    public partial class City
    {
        public City()
        {
            Area = new HashSet<Area>();
        }

        public int ObjId { get; set; }
        public int TheCity { get; set; }
        public string Cname { get; set; }
        public int TheProvince { get; set; }

        public Province TheProvinceNavigation { get; set; }
        public ICollection<Area> Area { get; set; }
    }
}
