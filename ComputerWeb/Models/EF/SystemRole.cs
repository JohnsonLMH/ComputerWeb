using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF
{
    public partial class SystemRole
    {
        public SystemRole()
        {
            SystemUser = new HashSet<SystemUser>();
        }

        public int Objid { get; set; }
        public string Sname { get; set; }
        public int TheRole { get; set; }

        public ICollection<SystemUser> SystemUser { get; set; }
    }
}
