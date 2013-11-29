using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Common;

namespace Weibo.API
{
    /// <summary>
    /// 获取用户的关注列表
    /// https://api.weibo.com/2/friendships/friends.json
    /// GET
    /// 需要登录授权
    /// 访问级别： 普通接口
    /// 频次限制：是
    /// 参数            必选	    类型及范围	说明
    /// source	        false	string	采用OAuth授权方式不需要此参数，其他授权方式为必填参数，数值为应用的AppKey。
    /// access_token	false	string	采用OAuth授权方式为必填参数，其他授权方式不需要此参数，OAuth授权后获得。
    /// uid	            false	int64	需要查询的用户ID。
    /// screen_name	    false	string	需要查询的用户昵称。
    /// count           false   int     单页返回的记录条数，默认为50，最大不超过200。
    /// cursor          false   int     返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。
    /// trim_status     false   int     返回值中user字段中的status字段开关，0：返回完整status字段、1：status字段仅返回status_id，默认为1。
    /// 参数uid与screen_name二者必选其一，且只能选其一
    /// </summary>
    public class Friends : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/friends.json", TYPE_FRIENDSHIPS); }
        }

        public string AccessToken { get; set; }

        public string UId { get; set; }

        public string ScreenName { get; set; }

        public override void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            this.NameValues["source"] = Const.APPKEY;
            this.NameValues["access_token"] = this.AccessToken;
            this.NameValues["uid"] = this.UId;
            base.AddAdditionalParams(parameters);
        }
    }
}
