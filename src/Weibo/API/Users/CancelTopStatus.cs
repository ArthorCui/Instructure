using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Common;

namespace Weibo.API
{
    /// <summary>
    /// 取消当前用户主页置顶微博
    /// https://api.weibo.com/2/users/cancel_top_status.json
    /// GET
    /// 需要登录授权
    /// 访问级别： 高级接口
    /// 频次限制：是
    /// 参数            必选	    类型及范围	说明
    /// source	        false	string	采用OAuth授权方式不需要此参数，其他授权方式为必填参数，数值为应用的AppKey。
    /// access_token	false	string	采用OAuth授权方式为必填参数，其他授权方式不需要此参数，OAuth授权后获得。
    /// id	            true    Int64	需要取消设置为置顶微博的微博ID。
    /// </summary>
    public class CancelTopStatus : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/cancel_top_status.json", TYPE_USERS); }
        }

        public string AccessToken { get; set; }

        public Int64 Id { get; set; }

        public override void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            this.NameValues["source"] = Const.APPKEY;
            this.NameValues["access_token"] = this.AccessToken;
            this.NameValues["id"] = this.Id.ToString();
            base.AddAdditionalParams(parameters);
        }
    }
}
