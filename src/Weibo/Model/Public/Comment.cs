using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 评论
    /// </summary>
    [Serializable]
    public class Comment
    {
        /// <summary>
        /// 评论创建时间
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 评论的ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Int64 Id { get; set; }

        /// <summary>
        /// 评论的内容
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// 评论的来源
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        /// <summary>
        /// 评论作者的用户信息字段
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }

        /// <summary>
        /// 评论的MID
        /// </summary>
        [JsonProperty(PropertyName = "mid")]
        public string Mid { get; set; }

        /// <summary>
        /// 字符串型的评论ID
        /// </summary>
        [JsonProperty(PropertyName = "idstr")]
        public string IdStr { get; set; }

        /// <summary>
        /// 评论的微博信息字段
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public Status Status { get; set; }

        /// <summary>
        /// 评论来源评论，当本评论属于对另一评论的回复时返回此字段
        /// </summary>
        [JsonProperty(PropertyName = "reply_comment")]
        public object ReplyComment { get; set; }
    }
}
