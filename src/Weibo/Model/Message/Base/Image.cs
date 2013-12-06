using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 图片类型私信和留言消息
    /// </summary>
    [Serializable]
    public class Image
    {
        /// <summary>
        /// 图片ID，发送者通过此ID读取图片
        /// </summary>
        [JsonProperty(PropertyName = "vfid")]
        public string VFId { get; set; }

        /// <summary>
        /// 图片ID，接收者通过此ID读取图片
        /// </summary>
        [JsonProperty(PropertyName = "tovfid")]
        public string ToVFId { get; set; }
    }
}
