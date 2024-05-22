using SignalR.BusinessLAyer.Abstract;
using SignalR.DataAccessLayer.Absract;
using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLAyer.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailsDal _OrderDetailDetailsDal;
public OrderDetailManager(IOrderDetailsDal OrderDetailDetailsDal)
        {
            _OrderDetailDetailsDal = OrderDetailDetailsDal;
        }

        public void TAdd(OrderDetail entity)
        {
            _OrderDetailDetailsDal.Add(entity);
        }

        public void TDelete(OrderDetail entity)
        {
            _OrderDetailDetailsDal.Delete(entity);
        }

        public OrderDetail TGetByID(int id)
        {
            return _OrderDetailDetailsDal.GetByID(id);
        }

        public List<OrderDetail> TGetListAll()
        {
            return _OrderDetailDetailsDal.GetListAll();
        }

        public void TUpdate(OrderDetail entity)
        {
            _OrderDetailDetailsDal.Update(entity);
        }
    }
}
