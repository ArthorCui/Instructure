using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 短链
    /// </summary>
    [Serializable]
    public class UrlShort
    {
        /// <summary>
        /// 短链接
        /// </summary>
        [JsonProperty(PropertyName = "url_short")]
        public string ShortUrl { get; set; }

        /// <summary>
        /// 原始长链接
        /// </summary>
        [JsonProperty(PropertyName = "url_long")]
        public string LongUrl { get; set; }

        /// <summary>
        /// 链接的类型，0：普通网页、1：视频、2：音乐、3：活动、5、投票
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }

        /// <summary>
        /// 短链的可用状态，true：可用、false：不可用。
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public bool Result { get; set; }
    }
}
