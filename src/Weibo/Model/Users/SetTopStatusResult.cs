using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    [Serializable]
    public class SetTopStatusResult
    {
        /// <summary>
        /// 置顶微博结果
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public bool Result { get; set; }
    }
}
