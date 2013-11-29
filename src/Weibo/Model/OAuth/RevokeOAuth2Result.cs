using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 应用情况：
    /// 1 应用下线时，清空所有用户的授权
    /// 2 应用新上线了功能，需要取得用户scope权限，可以回收后重新引导用户授权
    /// 3 开发者调试应用，需要反复调试授权功能
    /// 4 应用内实现类似登出新浪微博帐号的功能
    /// </summary>
    [Serializable]
    public class RevokeOAuth2Result
    {
        /// <summary>
        /// true 成功退出
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }
    }
}
