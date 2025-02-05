﻿using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Absract;
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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByTableNumber(int tableNumber)
        {
            using var context = new SignalRContext();
            var values=context.Baskets.Where(x=>x.MenuTableID==tableNumber).Include(y=>y.Product).ToList();
            return values;
        }

        public void UpdateOrCreateBasketCount(Basket basket)
        {
            using var context = new SignalRContext();
            var value = context.Baskets.Where(x => x.ProductID == basket.ProductID && x.MenuTableID == basket.MenuTableID).FirstOrDefault();

            if (value != null)
            {
                value.Count += basket.Count;
                value.Price=basket.Price;
                value.TotalPrice = value.Count * value.Price;
                context.SaveChanges();
            }
            else
            {
                basket.TotalPrice=basket.Price*basket.Count;
                context.Add(basket);
                context.SaveChanges();
            }
        }
    }
}
