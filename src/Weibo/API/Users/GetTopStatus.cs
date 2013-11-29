using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Common;

namespace Weibo.API
{
    /// <summary>
    /// 获取用户主页置顶微博
    /// https://api.weibo.com/2/users/get_top_status.json
    /// GET
    /// 需要登录授权
    /// 访问级别： 高级接口
    /// 频次限制：是
    /// 参数            必选	    类型及范围	说明
    /// source	        false	string	采用OAuth授权方式不需要此参数，其他授权方式为必填参数，数值为应用的AppKey。
    /// access_token	false	string	采用OAuth授权方式为必填参数，其他授权方式不需要此参数，OAuth授权后获得。
    /// uid	            true    Int64	需要查询的用户UID。
    /// </summary>
    public class GetTopStatus : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/get_top_status.json", TYPE_USERS); }
        }

        public string AccessToken { get; set; }

        public Int64 UId { get; set; }

        public override void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            this.NameValues["source"] = Const.APPKEY;
            this.NameValues["access_token"] = this.AccessToken;
            this.NameValues["uid"] = this.UId.ToString();
            base.AddAdditionalParams(parameters);
        }
    }
}
