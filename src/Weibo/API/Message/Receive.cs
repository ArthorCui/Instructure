using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Common;

namespace Weibo.API
{
    /// <summary>
    /// 消息推送接口，长连接微博推送服务，接收推送给指定蓝V用户的新消息。当有微博用户给蓝V发送新消息时，推送服务将此新消息格式化后由此长连接推送给该应用。
    /// https://m.api.weibo.com/2/messages/receive.json
    /// GET
    /// 需要登录授权
    /// 访问级别： 普通接口
    /// 频次限制：是
    /// 参数        类型及范围  必选	   	说明
    /// source	    string	   true	申请应用时分配的AppKey，调用接口时候代表应用的唯一身份。
    /// uid	        int64	   true	需要接收的蓝V用户ID。
    /// since_id	int64	   false	上次连接断开时的消息ID。保存断开后5分钟内的新消息，可以通过since_id获取断开五分钟内的新消息。
    /// 1、为确保应用及V用户信息安全，此接口必须在服务器端调用；
    /// 2、调用接口的登录帐号为该appkey的所有者，需要使用所有者帐号通过Base Auth的方式；
    /// 3、如appkey已绑定IP地址，调用接口的请求IP须为绑定的IP；
    /// 4、指定的uid用户为蓝V；
    /// 5、指定的uid用户已指定当前应用为其开发，且指定的uid用户已开启“开发模式”，详见：粉丝服务开发模式指南;
    /// 6、每条完整的新消息数据以json形式返回，默认采用UTF-8编码，且以\r\n分隔；
    /// 7、新消息来源用户为蓝V且已开启消息服务时，新消息不推送；
    /// 8、非常重要：此接口非短连接接口，需要以长连接方式调用；
    /// 9、非常重要：为缓解服务压力，请求建立后约每5分钟会自动断开（如未自动断开请用程序断开），应用需兼容根据最后一次
    /// 获取的新消息ID重新调此接口连接。
    /// 10、非常重要：当接收到的消息类型为text，且内容为“dy”或“td”时，分别表示“订阅”和“退订”；当接收到的消息类型为event，
    /// 且subtype为“subscribe”或“unsubscribe”时，分别表示“订阅”和“退订”。

    /// </summary>
    public class Receive : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/receive.json", TYPE_MESSAGES); }
        }

        public string UId { get; set; }

        public string SinceId { get; set; }

        public override void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            this.NameValues["source"] = Const.APPKEY;
            this.NameValues["uid"] = this.UId;
            base.AddAdditionalParams(parameters);
        }
    }
}
