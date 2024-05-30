using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLAyer.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
		void TChangeStatusToTrue(int id);
		void TChangeStatusToFalse(int id);
		List<Discount> TGetListByStatusTrue();
	}
}
