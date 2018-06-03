using System;
using System.Collections.Generic;

namespace ComputerWeb.Models
{
    public partial class Customer
    {
        public Customer()
        {
            ComputerOrder = new HashSet<ComputerOrder>();
            Consignee = new HashSet<Consignee>();
        }

        public int UserId { get; set; }
        public string Pwd { get; set; }
        public int TheCustomerType { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string OfficePhone { get; set; }
        public string HomePhone { get; set; }
        public string QqNumber { get; set; }

        public CustomerType TheCustomerTypeNavigation { get; set; }
        public ICollection<ComputerOrder> ComputerOrder { get; set; }
        public ICollection<Consignee> Consignee { get; set; }
    }
}
