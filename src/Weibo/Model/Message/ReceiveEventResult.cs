using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    public class ReceiveEventResult : ReceiveBaseResult
    {
        /// <summary>
        /// 消息事件内容
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public Event EventData { get; set; }
    }
}
