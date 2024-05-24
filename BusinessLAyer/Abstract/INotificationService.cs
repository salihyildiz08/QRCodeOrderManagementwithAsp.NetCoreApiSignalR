using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLAyer.Abstract
{
	public interface INotificationService:IGenericService<Notification>
	{
		int TNotificationCountByStatusFalse();
		List<Notification> TGetAllNotificationByFalse();
        void TNotificationStatusChangeToTrue(int id);
        void TNotificationStatusChangeToFalse(int id);

    }
}
