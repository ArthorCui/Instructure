using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    [Serializable]
    public class ReceiveVoiceResult : ReceiveResultBase
    {
        /// <summary>
        /// 消息事件内容
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public Voice VoiceData { get; set; }
    }
}
