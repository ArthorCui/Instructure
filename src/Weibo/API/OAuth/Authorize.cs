using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Common;

namespace Weibo.API
{
    /// <summary>
    /// OAuth2的authorize接口
    /// https://api.weibo.com/oauth2/authorize
    /// GET/POST
    /// client_id    true  string 申请应用时分配的AppKey。
    /// redirect_uri true  string 授权回调地址，站外应用需与设置的回调地址一致，站内应用需填写canvas page的地址。
    /// scope        false string 申请scope权限所需参数，可一次申请多个scope权限，用逗号分隔
    /// state        false string 用于保持请求和回调的状态，在回调时，会在Query Parameter中回传该参数。开发者可以用这个参数验证请求有效性，也可以记录用户请求授权页前的位置。这个参数可用于防止跨站请求伪造（CSRF）攻击
    /// display      false string 授权页面的终端类型，取值见下面的说明。
    /// forcelogin   false boolean 是否强制用户重新登录，true：是，false：否。默认false。
    /// language     false string 授权页语言，缺省为中文简体版，en为英文版。
    /// 
    /// display说明
    /// default    默认的授权页面，适用于web浏览器。
    /// mobile     移动终端的授权页面，适用于支持html5的手机。注：使用此版授权页请用 https://open.weibo.cn/oauth2/authorize 授权接口
    /// wap        wap版授权页面，适用于非智能手机。
    /// client     客户端版本授权页面，适用于PC桌面应用。
    /// apponweibo 默认的站内应用授权页，授权后不返回access_token，只刷新站内应用父框架。
    /// </summary>
    public class Authorize : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/authorize", TYPE_OAUTH); }
        }

        public string RedirectUrl { get; set; }

        public override void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            this.NameValues["client_id"] = Const.APPKEY;
            this.NameValues["redirect_uri"] = this.RedirectUrl;
            base.AddAdditionalParams(parameters);
        }
    }
}
