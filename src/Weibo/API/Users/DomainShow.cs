using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Common;

namespace Weibo.API.Users
{
    /// <summary>
    /// 通过个性化域名获取用户资料以及用户最新的一条微博
    /// https://api.weibo.com/2/users/domain_show.json
    /// GET
    /// 需要登录授权
    /// 访问级别： 普通接口
    /// 频次限制：是
    /// 参数            必选	    类型及范围	说明
    /// source	        false	string	采用OAuth授权方式不需要此参数，其他授权方式为必填参数，数值为应用的AppKey。
    /// access_token	false	string	采用OAuth授权方式为必填参数，其他授权方式不需要此参数，OAuth授权后获得。
    /// domain	        true    string	需要查询的个性化域名。
    /// </summary>
    public class DomainShow : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/domain_show.json", TYPE_USERS); }
        }

        public string AccessToken { get; set; }

        public string Domain { get; set; }

        public override void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            this.NameValues["source"] = Const.APPKEY;
            this.NameValues["access_token"] = this.AccessToken;
            this.NameValues["domain"] = this.Domain;
            base.AddAdditionalParams(parameters);
        }
    }
}
