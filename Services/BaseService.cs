using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMonitor.Clients;

namespace TestMonitor.Services
{
    public class BaseService
    {
        protected ApiClient apiClient;

        public BaseService(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }
    }
}