﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLAyer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        int TCategoryCount();
        int TActiveCategoryCount();
        int TPassiveCategoryCount();
    }
}
