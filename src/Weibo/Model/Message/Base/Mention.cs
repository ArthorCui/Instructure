using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 被@消息
    /// 说明：指定的蓝V需被授予接收“被@消息”权限，此接口才返回“被@消息”，申请可邮件 open_api@sina.com 
    /// </summary>
    [Serializable]
    public class Mention
    {
        /// <summary>
        /// status：@的微博，comment：@的评论
        /// </summary>
        [JsonProperty(PropertyName = "subtype")]
        public string SubType { get; set; }

        /// <summary>
        /// 当subtype为status时为微博ID，为comment时为评论ID
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
    }
}
