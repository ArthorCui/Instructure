using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    [Serializable]
    public class AccessTokenResult
    {
        /// <summary>
        /// 用于调用access_token，接口获取授权后的access token
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// access_token的生命周期，单位是秒数
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// access_token的生命周期（该参数即将废弃，开发者请使用expires_in）
        /// </summary>
        [JsonProperty(PropertyName = "remind_in")]
        public string RemindIn { get; set; }

        /// <summary>
        /// 当前授权用户的UID
        /// </summary>
        [JsonProperty(PropertyName = "uid")]
        public string UId { get; set; }
    }
}
