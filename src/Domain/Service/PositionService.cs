using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Model.LBS;
using Newtonsoft.Json.Linq;

namespace Domain.Service
{
    public class PositionService
    {
        #region Google
        public string ErrorMessage;

        public string GetLatLon(string LBS)
        {
            string location = string.Empty;
            string strKey = "LynnPortal_Position_LBS: " + LBS;

            location = GetLocationInfomation(LBS);
            return location;
        }

        /// <summary>
        /// 
        /// 返回经纬度信息
        /// 格式如下：
        /// 22.506421,113.918245|22.497636,113.912647|22.496063,113.91121   
        /// </summary>
        /// <param name="postData"></param>
        /// 
        /// <returns></returns> 
        public string GetLocationInfomation(string LBS)
        {
            List<CellInfo> list = GetCellInfos(LBS);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                CellInfo info = list[i];
                //基本步骤
                //1. 生成发往google的json串
                //2. 接收google返回的json串
                //3. 解析json串，取得经纬度
                //4. 拼接经纬度
                string json = GenerateRequestJson(info);
                string content = GetResponseJson(json);
                string latLon = ParseResponseJson(content);
                sb.Append(latLon);
                sb.Append("|");
            }
            return sb.ToString().Substring(0, sb.Length - 1);

        }

        /// <summary>
        /// 
        /// 接收从手机端发送过来的数据
        /// 
        /// '|'分割对象，','分割属性
        /// </summary>
        /// <param name="postData"></param>
        /// 
        /// <returns></returns>
        private List<CellInfo> GetCellInfos(string LBS)
        {
            string[] strInfos = LBS.Split('|');
            List<CellInfo> list = new List<CellInfo>();
            for (int i = 0; i < strInfos.Length; i++)
            {
                string[] properties = strInfos[i].Split(':');
                CellInfo info = new CellInfo();
                info.CID = properties[0];
                info.LAC = properties[1];
                info.MCC = properties[2];
                info.MNC = properties[3];

                list.Add(info);
            }

            return list;
        }

        /// <summary>
        /// 解析从google Response的JSON串，获取经纬度
        /// </summary>
        /// <param name="responseJson"></param>
        /// <returns></returns>
        private string ParseResponseJson(string responseJson)
        {
            StringBuilder latLon = new StringBuilder();
            JObject obj = JObject.Parse(responseJson);
            string lat = obj["location"]["latitude"].ToString();
            string lon = obj["location"]["longitude"].ToString();
            latLon.Append(lat);
            latLon.Append(",");
            latLon.Append(lon);
            return latLon.ToString();
        }

        /// <summary>
        /// 
        /// 发送一个基站信息，并返回一个位置信息
        /// 位置信息是以json串的形式存在
        /// 需要对json串进行解析
        /// </summary>
        /// 
        /// <param name="requestJson"></param>
        private string GetResponseJson(string requestJson)
        {
            string responseJson = string.Empty;
            try
            {
                ServicePointManager.Expect100Continue = false;
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] data = encoding.GetBytes(requestJson);
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(@"http://www.google.com/loc/json");
                myRequest.Method = "POST";
                myRequest.ContentType = "application/requestJson";
                myRequest.ContentLength = data.Length;
                Stream newStream = myRequest.GetRequestStream();

                // Send the data.
                newStream.Write(data, 0, data.Length);
                newStream.Close();

                // Get response JSON string
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.Default);
                responseJson = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return responseJson;
        }

        /// <summary>
        /// 生成发往http://www.google.com/loc/json的json串
        /// 仅仅只有一个基站
        /// </summary>
        /// <param name="info"></param>
        /// 
        /// <returns></returns>
        private string GenerateRequestJson(CellInfo info)
        {
            string json = "";
            json += "{";
            json += "\"version\":\"1.1.0\"" + ",";
            json += "\"host\":\"maps.google.com\"" + ",";
            json += "\"cell_towers\":[";
            json += "{";
            json += "\"cell_id\":" + info.CID + ",";
            json += "\"location_area_code\":" + info.LAC + ",";
            json += "\"mobile_country_code\":" + info.MCC + ",";
            json += "\"mobile_network_code\":" + info.MNC;
            json += "}";
            json += "],";
            json += "\"wifi_towers\": [{}]";
            json += "}";
            return json;
        }

        #endregion
    }

}
