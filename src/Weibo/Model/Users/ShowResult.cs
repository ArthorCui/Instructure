using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    [Serializable]
    public class ShowResult : User
    {
        /// <summary>
        /// 用户UID
        /// </summary>
        [JsonProperty(PropertyName = "uid")]
        public override Int64 Id { get; set; }
    }
}
