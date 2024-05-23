using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Concrete
{
    public class Basket
    {
        public int BasketID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPri { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int MenuTableID { get; set; }
        public MenuTable MenuTable { get; set; }
    }
}
