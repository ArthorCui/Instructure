using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    [Serializable]
    public class AuthorizeResult
    {
        /// <summary>
        /// 用于调用access_token，接口获取授权后的access token
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 如果传递参数，会回传该参数
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
    }
}
