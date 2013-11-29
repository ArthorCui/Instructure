using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    [Serializable]
    public class RateLimitStatusResult
    {
        /// <summary>
        /// IP频次限制
        /// </summary>
        [JsonProperty(PropertyName = "ip_limit")]
        public int IPLimit { get; set; }

        /// <summary>
        /// 限制时间单位
        /// </summary>
        [JsonProperty(PropertyName = "limit_time_unit")]
        public string LimitTimeUnit { get; set; }

        /// <summary>
        /// 剩余的IP点击频次
        /// </summary>
        [JsonProperty(PropertyName = "remaining_ip_hits")]
        public int RemainingIPHits { get; set; }

        /// <summary>
        /// 剩余的用户点击频次
        /// </summary>
        [JsonProperty(PropertyName = "remaining_user_hits")]
        public int RemainingUserHits { get; set; }

        /// <summary>
        /// 重置时间
        /// </summary>
        [JsonProperty(PropertyName = "reset_time")]
        public DateTime ResetTime { get; set; }

        /// <summary>
        /// 重置时间以秒为单位
        /// </summary>
        [JsonProperty(PropertyName = "reset_time_in_seconds")]
        public int ResetTimeInSeconds { get; set; }

        /// <summary>
        /// 用户频次限制
        /// </summary>
        [JsonProperty(PropertyName = "user_limit")]
        public int UserLimit { get; set; }
    }
}
