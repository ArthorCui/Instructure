using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.API
{
    /// <summary>
    /// 功能： 消息发送接口，蓝V给粉丝发送一对一私信接口
    /// https://m.api.weibo.com/2/messages/send.json
    /// POST
    /// 需要登录授权
    /// 访问级别： 普通接口
    /// 频次限制：是
    /// 参数        类型及范围   必选	   	说明
    /// source	    string	    true	申请应用时分配的AppKey，调用接口时候代表应用的唯一身份。
    /// sender_id	int64	    true	消息发送方的用户ID。
    /// receiver_id	int64	    true	消息接收方的用户ID。
    /// type	    string	    true	需要以何种类型的消息类型发送。text：纯文本类型私信。
    /// data	    string	    false	消息数据，具体内容严格遵循type类型对应格式。必须为json做URLEncode后的字符串格式，采用UTF-8编码。
    /// annotations	string	    false	元数据，主要是为了方便第三方应用记录一些适合于自己使用的信息。每条微博可以包含一个或者多个元数据。必须为json做URLEncode后的字符串格式，字串长度不超过512个字符，具体内容可以自定。例：annotations='[{"type2":123}, {"a":"b", "c":"d"}]'; 。
    /// 1、为确保应用及V用户信息安全，此接口必须在服务器端调用；
    /// 2、调用接口的登录帐号必须为该appkey的创建者，需要使用创建者帐号通过Base Auth的方式；
    /// 3、如appkey已绑定IP地址，调用接口的请求IP须为绑定的IP；
    /// 4、指定的sender_id用户已指定当前应用为其开发，且指定的sender_id用户已开启“开发模式”，详见：粉丝服务开发模式指南;
    /// 5、指定sender_id的用户为蓝V；
    /// 6、指定sender_id的用户具有一对一消息的权限；
    /// 7、指定的receiver_id用户必须为sender_id用户的粉丝；未明确告知用户关注后将获得哪些服务提醒的蓝V，从而导致用户投诉将无限期关停接口。
    /// </summary>
    public class Send : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/send.json", TYPE_MESSAGES); }
        }
    }
}
