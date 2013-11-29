using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Common;

namespace Weibo.API
{
    /// <summary>
    /// 获取所有的学校列表
    /// https://api.weibo.com/2/account/profile/school_list.json
    /// GET
    /// 需要登录授权
    /// 访问级别：普通接口
    /// 频次限制：是
    /// 参数            必选	    类型及范围	说明
    /// source	        false	string	采用OAuth授权方式不需要此参数，其他授权方式为必填参数，数值为应用的AppKey。
    /// access_token	false	string	采用OAuth授权方式为必填参数，其他授权方式不需要此参数，OAuth授权后获得。
    /// province	    false	int	省份范围，省份ID。
    /// city	        false	int	城市范围，城市ID。
    /// area	        false	int	区域范围，区ID。
    /// type	        false	int	学校类型，1：大学、2：高中、3：中专技校、4：初中、5：小学，默认为1。
    /// capital	        false	string	学校首字母，默认为A。
    /// keyword	        false	string	学校名称关键字。
    /// count	        false	int	返回的记录条数，默认为10。
    /// </summary>
    public class SchoolList : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/school_list.json", TYPE_ACCOUNT); }
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
