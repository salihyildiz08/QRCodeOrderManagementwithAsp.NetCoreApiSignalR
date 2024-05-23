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
            var values=context.Baskets.Where(x=>x.MenuTableID==tableNumber).ToList();
            return values;
        }
    }
}
