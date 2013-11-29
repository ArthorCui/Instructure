using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    [Serializable]
    public class GetPrivacyResult
    {
        /// <summary>
        /// 是否可以评论我的微博，0：所有人、1：关注的人、2：可信用户
        /// </summary>
        [JsonProperty(PropertyName = "comment")]
        public int Comment { get; set; }

        /// <summary>
        /// 是否开启地理信息，0：不开启、1：开启
        /// </summary>
        [JsonProperty(PropertyName = "geo")]
        public int Geo { get; set; }

        /// <summary>
        /// 是否可以给我发私信，0：所有人、1：我关注的人、2：可信用户
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public int Message { get; set; }

        /// <summary>
        /// 是否可以通过真名搜索到我，0：不可以、1：可以
        /// </summary>
        [JsonProperty(PropertyName = "realname")]
        public int RealName { get; set; }

        /// <summary>
        /// 勋章是否可见，0：不可见、1：可见
        /// </summary>
        [JsonProperty(PropertyName = "badge")]
        public int Badge { get; set; }

        /// <summary>
        /// 是否可以通过手机号码搜索到我，0：不可以、1：可以
        /// </summary>
        [JsonProperty(PropertyName = "mobile")]
        public int Mobile { get; set; }

        /// <summary>
        /// 是否开启webim， 0：不开启、1：开启
        /// </summary>
        [JsonProperty(PropertyName = "webim")]
        public int Webim { get; set; }
    }
}
