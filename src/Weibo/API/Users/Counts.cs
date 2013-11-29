using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Common;

namespace Weibo.API
{
    /// <summary>
    /// 批量获取用户的粉丝数、关注数、微博数
    /// https://api.weibo.com/2/users/counts.json
    /// GET
    /// 需要登录授权
    /// 访问级别： 普通接口
    /// 频次限制：是
    /// 参数            必选	    类型及范围	说明
    /// source	        false	string	采用OAuth授权方式不需要此参数，其他授权方式为必填参数，数值为应用的AppKey。
    /// access_token	false	string	采用OAuth授权方式为必填参数，其他授权方式不需要此参数，OAuth授权后获得。
    /// uids	        true    string	需要获取数据的用户UID，多个之间用逗号分隔，最多不超过100个。
    /// </summary>
    public class Counts : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/counts.json", TYPE_USERS); }
        }

        public string AccessToken { get; set; }

        public string UIds { get; set; }

        public override void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            this.NameValues["source"] = Const.APPKEY;
            this.NameValues["access_token"] = this.AccessToken;
            this.NameValues["uids"] = this.UIds;
            base.AddAdditionalParams(parameters);
        }
    }
}
