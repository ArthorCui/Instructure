using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 事件消息
    /// </summary>
    [Serializable]
    public class Event
    {
        /// <summary>
        /// follow：关注事件，unfollow取消关注事件，subscribe订阅事件，unsubscribe订阅事件。
        /// </summary>
        [JsonProperty(PropertyName = "subtype")]
        public string SubType { get; set; }

        /// <summary>
        /// subtype为follow、unfollow、subscribe或unsubscribe时不返回
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
    }
}
