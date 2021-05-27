using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeCRUDWebApp.Helper
{
    public class EmployeeApiHelper
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44345/");
            return client;
            
        }
    }
}
