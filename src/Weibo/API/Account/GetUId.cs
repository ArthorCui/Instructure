using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Common;

namespace Weibo.API
{
    /// <summary>
    /// OAuth授权之后，获取授权用户的UID
    /// https://api.weibo.com/2/account/get_uid.json
    /// GET
    /// 需要登录授权
    /// 访问级别：普通接口
    /// 频次限制：否
    /// 参数            必选	    类型及范围	说明
    /// source	        false	string	采用OAuth授权方式不需要此参数，其他授权方式为必填参数，数值为应用的AppKey。
    /// access_token	false	string	采用OAuth授权方式为必填参数，其他授权方式不需要此参数，OAuth授权后获得。
    /// </summary>
    public class GetUId : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/get_uid.json", TYPE_ACCOUNT);}
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
