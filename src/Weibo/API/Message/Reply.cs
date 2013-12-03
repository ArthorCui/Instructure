using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Common;

namespace Weibo.API
{
    /// <summary>
    /// 功能： 消息回复接口，对接收到的指定新消息进行回复
    /// https://m.api.weibo.com/2/messages/reply.json
    /// POST
    /// 需要登录授权
    /// 访问级别： 普通接口
    /// 频次限制：是
    /// 参数        类型及范围   必选	   	说明
    /// source	    string	    true	申请应用时分配的AppKey，调用接口时候代表应用的唯一身份。
    /// id	        long	    true	需要响应的推送消息ID。
    /// type	    string	    true	需要以何种类型的消息进行响应。text：纯文本、articles：图文、position：位置。
    /// data	    string	    true	消息数据，具体内容严格遵循type类型对应格式。必须为json做URLEncode后的字符串格式，采用UTF-8编码。
    /// 1、为确保应用及V用户信息安全，此接口必须在服务器端调用；
    /// 2、调用接口的登录帐号必须为该appkey的所有者，需要使用所有者帐号通过Base Auth的方式；
    /// 3、如appkey已绑定IP地址，调用接口的请求IP须为绑定的IP；
    /// 4、指定ID的新消息对应的原接收者已指定当前应用为其开发，且该接收者已开启“开发模式”，详见：粉丝服务开发模式指南;
    /// 6、指定ID的新消息创建时间在72小时内；
    /// 7、指定的ID消息为“私信、留言”时72小时内可回复三次，为关注、取消关注事件等非私信消息72小时内可回复1次；
    /// 8、指定ID的新消息对应的原接收者身份发出此消息;
    /// 9、指定ID的新消息对应的原发送者将收到此消息;
    /// 10、发送者未被屏蔽或拉黑时消息进私信箱;
    /// </summary>
    public class Reply : InvocationBase
    {
        protected override string MethodName
        {
            get { return string.Format("{0}/reply.json", TYPE_MESSAGES); }
        }

        public long Id { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        public override void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            this.NameValues["source"] = Const.APPKEY;
            this.NameValues["id"] = this.Id.ToString();
            this.NameValues["type"] = this.Type;
            this.NameValues["data"] = this.Data;
            base.AddAdditionalParams(parameters);
        }
    }
}
