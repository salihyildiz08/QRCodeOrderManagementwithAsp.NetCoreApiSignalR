﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Absract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
         int CategoryCount();
         int ActiveCategoryCount();
         int PassiveCategoryCount();
    }
}
