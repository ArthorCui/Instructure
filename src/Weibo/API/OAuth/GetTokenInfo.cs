using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.API
{
    /// <summary>
    /// 查询用户access_token的授权相关信息，包括授权时间，过期时间和scope权限
    /// https://api.weibo.com/oauth2/get_token_info
    /// POST
    /// access_token：用户授权时生成的access_token
    /// </summary>
    public class GetTokenInfo : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/get_token_info", TYPE_OAUTH); }
        }

        public string AccessToken { get; set; }

        public override void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            this.NameValues["access_token"] = this.AccessToken;
            base.AddAdditionalParams(parameters);
        }
    }
}
