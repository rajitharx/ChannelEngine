using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine.ServiceManager
{
    public class BaseServiceManager
    {
        internal readonly IConfiguration _configuration;
        internal string apiKey = string.Empty;
        internal string apiURL = string.Empty;
        public BaseServiceManager(IConfiguration configuration)
        {
            _configuration = configuration;
            apiKey = _configuration["AppSetting:APIKey"];
            apiURL = _configuration["AppSetting:APIURL"];
        }


        //public OrderAPI(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    apiKey = _configuration["AppSetting:APIKey"];
        //}

    }
}
