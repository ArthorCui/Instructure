using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    [Serializable]
    public class GetUIdResult
    {
        /// <summary>
        /// 用户UID
        /// </summary>
        [JsonProperty(PropertyName = "uid")]
        public string UId { get; set; }
    }
}
