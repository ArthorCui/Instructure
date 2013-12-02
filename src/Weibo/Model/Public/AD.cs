using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 推广微博ID
    /// </summary>
    [Serializable]
    public class AD
    {
        /// <summary>
        /// 推广微博ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Int64 Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "mark")]
        public string Mark { get; set; }
    }
}
