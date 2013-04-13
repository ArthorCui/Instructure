using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Web.Http
{
    public class HttpBase
    {
        private WebRequest request;

        private Stream dataStream;

        private string status;

        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public HttpBase(string url)
        {
            // Create a request using a URL that can receive a post.
            request = WebRequest.Create(url);
        }

        public HttpBase(string url, string method)
            : this(url)
        {
            if (method.Equals("GET") || method.Equals("POST"))
            {
                // Set the Method property of the request to POST.
                request.Method = method;
            }
            else
            {
                throw new Exception("Invalid Method Type");
            }
        }

        public HttpBase(string url, string method, string data)
            : this(url, method)
        {
            // Create POST data and convert it to a byte array.
            string postData = data;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";

            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Close the Stream object.
            dataStream.Close();
        }

        public string GetResponse()
        {
            // Get the original response.
            WebResponse response = request.GetResponse();
            this.Status = ((HttpWebResponse)response).StatusDescription;

            // Get the stream containing all content returned by the requested server.
            dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            // Read the content fully up to the end.
            string responseFromServer = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
    }

    public class HttpBaseTest
    {
        public string SendRequest(string param)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(param);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://itest.kk570.com/ota/checkupdate");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream sm = request.GetRequestStream();
            sm.Write(data, 0, data.Length);
            sm.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode.ToString() != "OK")
            {
                return "";
            }

            using (StreamReader myreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                string responseText = myreader.ReadToEnd();
            }
            return "";

        }
    }
}
