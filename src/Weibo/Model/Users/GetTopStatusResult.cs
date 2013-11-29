using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    [Serializable]
    public class GetTopStatusResult
    {
        /// <summary>
        /// 微博UID
        /// </summary>
        [JsonProperty(PropertyName = "uid")]
        public Int64 UId { get; set; }

        /// <summary>
        /// 微博标识ID
        /// </summary>
        [JsonProperty(PropertyName = "mid")]
        public string MId { get; set; }

        /// <summary>
        /// 是否有置顶微博
        /// </summary>
        [JsonProperty(PropertyName = "is_use")]
        public bool IsUse { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty(PropertyName = "create_at")]
        public DateTime CreateAt { get; set; }
    }
}
