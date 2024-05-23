using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.Absract
{
    public interface IBasketDal:IGenericDal<Basket>
    {
        List<Basket> GetBasketByTableNumber(int tableNumber);
        void UpdateOrCreateBasketCount(Basket basket);

    }
}
