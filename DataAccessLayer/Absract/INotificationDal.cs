﻿using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Absract
{
	public interface INotificationDal:IGenericDal<Notification>
	{
		int NotificationCountByStatusFalse();
		List<Notification> GetAllNotificationByFalse();

		void NotificationStatusChangeToTrue(int id);
		void NotificationStatusChangeToFalse(int id);

    }
}