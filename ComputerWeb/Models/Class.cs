using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWeb.Models
{
    public class Class
    {
        private int userId;
        private string cname;
        private string mobilePhone;
        private int theOrder;
        private int productId;
        private DateTime timetommarket;
        private string productName;
        private string productState;
        private DateTime orderTime;
        private string conname;
        private string conMobilePhone;
        private string orderState;

        public int UserId { get => userId; set => userId = value; }
        public string Cname { get => cname; set => cname = value; }
        public string MobilePhone { get => mobilePhone; set => mobilePhone = value; }
        public int TheOrder { get => theOrder; set => theOrder = value; }
        public int ProductId { get => productId; set => productId = value; }
        public DateTime OrderTime { get => orderTime; set => orderTime = value; }
        public string Conname { get => conname; set => conname = value; }
        public string ConMobilePhone { get => conMobilePhone; set => conMobilePhone = value; }
        public string OrderState { get => orderState; set => orderState = value; }
        public string ProductName { get => productName; set => productName = value; }
        public DateTime Timetommarket { get => timetommarket; set => timetommarket = value; }
        public string ProductState { get => productState; set => productState = value; }
    }
}
