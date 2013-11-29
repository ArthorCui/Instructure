using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace Weibo.Service
{
    public class ServiceProxy
    {
        public string GetData(string url, Method method)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);
            var response = client.Execute(request);

            var content = response.Content;
            return content;
        }
    }
}
