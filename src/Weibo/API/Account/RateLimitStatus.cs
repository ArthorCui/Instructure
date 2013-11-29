using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Common;

namespace Weibo.API
{
    /// <summary>
    /// 获取当前登录用户的API访问频率限制情况
    /// https://api.weibo.com/2/account/rate_limit_status.json
    /// GET
    /// 需要登录授权
    /// 访问级别：普通接口
    /// 频次限制：否
    /// 参数            必选	    类型及范围	说明
    /// source	        false	string	采用OAuth授权方式不需要此参数，其他授权方式为必填参数，数值为应用的AppKey。
    /// access_token	false	string	采用OAuth授权方式为必填参数，其他授权方式不需要此参数，OAuth授权后获得。
    /// </summary>
    public class RateLimitStatus : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/rate_limit_status.json", TYPE_ACCOUNT); }
        }

        public string AccessToken { get; set; }

        public override void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            this.NameValues["source"] = Const.APPKEY;
            this.NameValues["access_token"] = this.AccessToken;
            base.AddAdditionalParams(parameters);
        }
    }
}
