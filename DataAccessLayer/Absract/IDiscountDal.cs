﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Absract
{
    public interface IDiscountDal : IGenericDal<Discount>
    {
		void ChangeStatusToTrue(int id);
		void ChangeStatusToFalse(int id);
		List<Discount> GetListByStatusTrue();
	}
}
