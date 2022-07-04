﻿using ChannelEngine.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine.ServiceManager.Interface
{
    public interface IProductAPI
    {
        Response<IList<MerchantProductResponse>> GetProductDetailsByFromAPI(string serachKey);
    }
}