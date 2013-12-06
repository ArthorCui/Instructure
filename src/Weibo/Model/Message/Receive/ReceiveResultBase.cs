using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 消息推送结果基类
    /// </summary>
    [Serializable]
    public class ReceiveResultBase
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// 消息的接收者
        /// </summary>
        [JsonProperty(PropertyName = "receiver_id")]
        public Int64 ReceiverId { get; set; }

        /// <summary>
        /// 消息的发送者
        /// </summary>
        [JsonProperty(PropertyName = "sender_id")]
        public Int64 SenderId { get; set; }

        /// <summary>
        /// 消息创建时间
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 默认文案。subtype为follow或unfollow时分别为“关注事件消息”、“取消关注事件消息”；为subscribe或unsubscribe时为触发订阅的私信关键词（如“dy”），非私信触发时（点击订阅按钮）为“订阅事件消息”、“取消订阅事件消息”。
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
