using System;
using System.Collections.Generic;

namespace ComputerWeb.Models.EF1
{
    public partial class Customer
    {
        public Customer()
        {
            ComputerOrder = new HashSet<ComputerOrder>();
            Consignee = new HashSet<Consignee>();
            Favorites = new HashSet<Favorites>();
            ShoppingCart = new HashSet<ShoppingCart>();
        }

        public int ObjId { get; set; }
        public int UserId { get; set; }
        public string Cname { get; set; }
        public string Pwd { get; set; }
        public int TheCustomerType { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }

        public CustomerType TheCustomerTypeNavigation { get; set; }
        public ICollection<ComputerOrder> ComputerOrder { get; set; }
        public ICollection<Consignee> Consignee { get; set; }
        public ICollection<Favorites> Favorites { get; set; }
        public ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
