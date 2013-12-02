using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 微博配图
    /// </summary>
    [Serializable]
    public class PicUrls
    {
        /// <summary>
        /// 微博配图地址。多图时返回多图链接。无配图返回“[]”
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail_pic")]
        public List<string> ThumbnailPic { get; set; }

    }
}
