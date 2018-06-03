using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class Province
    {
        public Province()
        {
            City = new HashSet<City>();
        }

        public int ObjId { get; set; }
        public int TheProvince { get; set; }
        public string Pname { get; set; }

        public ICollection<City> City { get; set; }
    }
}
