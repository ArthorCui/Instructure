using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    [Serializable]
    public class GetTokenInfoResult
    {
        /// <summary>
        /// 授权用户的uid
        /// </summary>
        [JsonProperty(PropertyName = "uid")]
        public string UId { get; set; }

        /// <summary>
        /// access_token所属的应用appkey
        /// </summary>
        [JsonProperty(PropertyName = "appkey")]
        public string AppKey { get; set; }

        /// <summary>
        /// 用户授权的scope权限
        /// </summary>
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        /// <summary>
        /// access_token的创建时间，从1970年到创建时间的秒数
        /// </summary>
        [JsonProperty(PropertyName = "create_at")]
        public string CreateAt { get; set; }

        /// <summary>
        /// access_token的剩余时间，单位是秒数
        /// </summary>
        [JsonProperty(PropertyName = "expire_in")]
        public string ExpireIn { get; set; }
    }
}
