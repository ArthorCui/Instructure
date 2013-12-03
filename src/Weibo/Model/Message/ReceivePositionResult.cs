using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    [Serializable]
    public class ReceivePositionResult : ReceiveBaseResult
    {
        /// <summary>
        /// 消息事件内容
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public Position PositionData { get; set; }
    }
}
