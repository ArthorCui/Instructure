using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 语音类型私信和留言消息
    /// </summary>
    [Serializable]
    public class Voice
    {
        /// <summary>
        /// 语音文件ID，发送者通过此ID读取语音
        /// </summary>
        [JsonProperty(PropertyName = "vid")]
        public string VId { get; set; }

        /// <summary>
        /// 语音文件ID，接收者通过此ID读取语音
        /// </summary>
        [JsonProperty(PropertyName = "tovid")]
        public string ToVId { get; set; }
    }
}
