using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Common;

namespace Weibo.API
{
    /// <summary>
    /// OAuth2的access_token接口
    /// https://api.weibo.com/oauth2/access_token
    /// POST
    ///               必选	类型及范围	说明
    /// client_id     true	string	申请应用时分配的AppKey。
    /// client_secret true	string	申请应用时分配的AppSecret。
    /// grant_type    true	string	请求的类型，填写authorization_code
    ///
    /// grant_type为authorization_code时
    ///              必选	类型及范围	说明
    /// code         true string	调用authorize获得的code值。
    /// redirect_uri true string	回调地址，需与注册应用里的回调地址一致。
    /// </summary>
    public class AccessToken : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/access_token", TYPE_OAUTH); }
        }

        public string AuthorizationCode { get; set; }

        public override void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            this.NameValues["client_id"] = Const.APPKEY;
            this.NameValues["client_secret"] = Const.APPSERCET;
            this.NameValues["grant_type"] = this.AuthorizationCode;
            base.AddAdditionalParams(parameters);
        }
    }
}
