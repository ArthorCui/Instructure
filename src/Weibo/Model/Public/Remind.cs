using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 消息未读数
    /// </summary>
    [Serializable]
    public class Remind
    {
        /// <summary>
        /// 新微博未读数
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        /// <summary>
        /// 新粉丝数
        /// </summary>
        [JsonProperty(PropertyName = "follower")]
        public int Follower { get; set; }

        /// <summary>
        /// 新评论数
        /// </summary>
        [JsonProperty(PropertyName = "cmt")]
        public int Cmt { get; set; }

        /// <summary>
        /// 新私信数
        /// </summary>
        [JsonProperty(PropertyName = "dm")]
        public int Dm { get; set; }

        /// <summary>
        /// 新提及我的微博数
        /// </summary>
        [JsonProperty(PropertyName = "mention_status")]
        public int MentionStatus { get; set; }

        /// <summary>
        /// 新提及我的评论数
        /// </summary>
        [JsonProperty(PropertyName = "mention_cmt")]
        public int MentionCmt { get; set; }

        /// <summary>
        /// 微群消息未读数
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public int Group { get; set; }

        /// <summary>
        /// 私有微群消息未读数
        /// </summary>
        [JsonProperty(PropertyName = "private_group")]
        public int PrivateGroup { get; set; }


        /// <summary>
        /// 新通知未读数
        /// </summary>
        [JsonProperty(PropertyName = "notice")]
        public int Notice { get; set; }

        /// <summary>
        /// 新邀请未读数
        /// </summary>
        [JsonProperty(PropertyName = "invite")]
        public int Invite { get; set; }

        /// <summary>
        /// 新勋章数
        /// </summary>
        [JsonProperty(PropertyName = "badge")]
        public int Badge { get; set; }

        /// <summary>
        /// 相册消息未读数
        /// </summary>
        [JsonProperty(PropertyName = "photo")]
        public int Photo { get; set; }

        /// <summary>
        /// {{{3}}}
        /// </summary>
        [JsonProperty(PropertyName = "msgbox")]
        public int MsgBox { get; set; }
    }
}
