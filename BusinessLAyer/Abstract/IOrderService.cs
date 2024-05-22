using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLAyer.Abstract
{
    public interface IOrderService:IGenericService<Order>
    {
        int TTotalOrderCount();
        int TActiveOrderCount();
        decimal TLastOrderPrice();
        decimal TTodayTotalPrice();


    }
}
