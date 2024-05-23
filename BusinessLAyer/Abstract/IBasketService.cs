using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLAyer.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        List<Basket> TGetBasketByTableNumber(int tableNumber);
        void TUpdateOrCreateBasketCount(Basket basket);
    }
}
