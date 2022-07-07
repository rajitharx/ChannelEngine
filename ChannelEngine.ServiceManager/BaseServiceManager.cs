using Microsoft.Extensions.Configuration;

namespace ChannelEngine.ServiceManager
{
    public class BaseServiceManager
    {
        /// <summary>
        /// Interface for Configuration
        /// </summary>
        internal readonly IConfiguration _configuration;

        /// <summary>
        /// declaration for API Key
        /// </summary>
        internal string apiKey = string.Empty;

        /// <summary>
        /// declaration for AAPI URL
        /// </summary>
        internal string apiURL = string.Empty;

        /// <summary>
        /// BaseServiceManager Constructor
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        public BaseServiceManager(IConfiguration configuration)
        {
            _configuration = configuration;
            apiKey = _configuration["APISetting:APIKey"];
            apiURL = _configuration["APISetting:APIURL"];
        }
    }
}