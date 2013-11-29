using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model.Users
{
    [Serializable]
    public class CountsResult
    {
        /// <summary>
        /// 微博ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Int64 Id { get; set; }

        /// <summary>
        /// 粉丝数
        /// </summary>
        [JsonProperty(PropertyName = "followers_count")]
        public int FollowersCount { get; set; }

        /// <summary>
        /// 关注数
        /// </summary>
        [JsonProperty(PropertyName = "friends_count")]
        public int FriendsCount { get; set; }

        /// <summary>
        /// 微博数
        /// </summary>
        [JsonProperty(PropertyName = "statuses_count")]
        public int StatusesCount { get; set; }

        /// <summary>
        /// 密友数
        /// 暂未支持
        /// </summary>
        [JsonProperty(PropertyName = "private_friends_count")]
        public int PrivateFriendsCount { get; set; }
    }
}
