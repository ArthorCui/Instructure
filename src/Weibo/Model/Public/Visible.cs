using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 微博可见性
    /// </summary>
    [Serializable]
    public class Visible
    {
        /// <summary>
        /// 微博类型
        /// type取值，0：普通微博，1：私密微博，3：指定分组微博，4：密友微博
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }

        /// <summary>
        /// 微博类型
        /// list_id为分组的组号
        /// </summary>
        [JsonProperty(PropertyName = "list_id")]
        public int ListId { get; set; }
    }
}
