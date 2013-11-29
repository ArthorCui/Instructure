using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 微博
    /// </summary>
    [Serializable]
    public class Status
    {
        /// <summary>
        /// 微博创建时间
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// 微博ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Int64 Id { get; set; }

        /// <summary>
        /// 微博MID
        /// </summary>
        [JsonProperty(PropertyName = "mid")]
        public Int64 MId { get; set; }

        /// <summary>
        /// 字符串型的微博ID
        /// </summary>
        [JsonProperty(PropertyName = "idstr")]
        public string IdStr { get; set; }

        /// <summary>
        /// 微博信息内容
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// 微博来源
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        /// <summary>
        /// 是否已收藏，true：是，false：否
        /// </summary>
        [JsonProperty(PropertyName = "favorited")]
        public bool Favorited { get; set; }

        /// <summary>
        /// 是否被截断，true：是，false：否
        /// </summary>
        [JsonProperty(PropertyName = "truncated")]
        public bool Truncated { get; set; }

        /// <summary>
        /// （暂未支持）回复ID
        /// </summary>
        [JsonProperty(PropertyName = "in_reply_to_status_id")]
        public string InReplyToStatusId { get; set; }

        /// <summary>
        /// （（暂未支持）回复人UID
        /// </summary>
        [JsonProperty(PropertyName = "in_reply_to_user_id")]
        public string InReplyToUserId { get; set; }

        /// <summary>
        /// （暂未支持）回复人昵称
        /// </summary>
        [JsonProperty(PropertyName = "in_reply_to_screen_name")]
        public string InReplyToScreenName { get; set; }

        /// <summary>
        /// 缩略图片地址，没有时不返回此字段
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail_pic")]
        public string ThumbnailPic { get; set; }

        /// <summary>
        /// 缩略图片地址，没有时不返回此字段
        /// </summary>
        [JsonProperty(PropertyName = "bmiddle_pic")]
        public string BmiddlePic { get; set; }

        /// <summary>
        /// 缩略图片地址，没有时不返回此字段
        /// </summary>
        [JsonProperty(PropertyName = "original_pic")]
        public string OriginalPic { get; set; }
    }
}
