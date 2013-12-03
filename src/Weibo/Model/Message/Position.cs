using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 位置类型私信消息
    /// </summary>
    [Serializable]
    public class Position
    {
        /// <summary>
        /// 经度
        /// </summary>
        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// 维度
        /// </summary>
        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }
    }
}
