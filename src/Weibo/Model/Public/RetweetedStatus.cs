using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 转发微博
    /// </summary>
    [Serializable]
    public class RetweetedStatus : Status
    {
        /// <summary>
        /// 转发数
        /// </summary>
        [JsonProperty(PropertyName = "retweeted_status")]
        [JsonIgnore]
        public override RetweetedStatus RetweeteStatus { get; set; }
    }
}
