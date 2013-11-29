using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.API
{
    /// <summary>
    /// 授权回收接口，帮助开发者主动取消用户的授权。
    /// https://api.weibo.com/oauth2/revokeoauth2
    /// GET/POST
    /// access_token: 用户授权应用的access_token
    /// </summary>
    public class RevokeOAuth2 : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/revokeoauth2", TYPE_OAUTH); }
        }

        public string AccessToken { get; set; }

        public override void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            this.NameValues["access_token"] = this.AccessToken;
            base.AddAdditionalParams(parameters);
        }
    }
}
