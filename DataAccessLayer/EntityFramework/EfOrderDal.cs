﻿using SignalR.DataAccessLayer.Absract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x=>x.Description== "customer at the table").Count();
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalRContext();
            return context.Orders.OrderByDescending(x=>x.OrderID).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();
            DateTime nowDate=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
            return context.Orders.Where(x => x.Description == "Account Closed" && x.Date==nowDate).Sum(y=>y.TotalPrice);
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
    }
}
