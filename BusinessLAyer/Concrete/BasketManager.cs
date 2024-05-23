using SignalR.BusinessLAyer.Abstract;
using SignalR.DataAccessLayer.Absract;
using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLAyer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public List<Basket> TGetBasketByTableNumber(int tableNumber)
        {
            return _basketDal.GetBasketByTableNumber(tableNumber);
        }

        public void TAdd(Basket entity)
        {
           _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public Basket TGetByID(int id)
        {
           return _basketDal.GetByID(id);
        }

        public List<Basket> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Basket entity)
        {
            _basketDal.Update(entity);
        }

        public void TUpdateOrCreateBasketCount(Basket basket)
        {
            _basketDal.UpdateOrCreateBasketCount(basket);
        }
    }
}
