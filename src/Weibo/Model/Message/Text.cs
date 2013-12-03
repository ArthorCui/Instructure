using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 纯文本类型私信和留言消息
    /// </summary>
    [Serializable]
    public class Text
    {
        /// <summary>
        /// 消息内容，纯文本私信或留言为空
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Content { get; set; }
    }
}
