using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Weibo.Service;

namespace Weibo
{
    public abstract class InvocationBase
    {
        #region Prop

        protected const string HOST = "https://api.weibo.com/";

        protected abstract string MethodName { get; }

        public const string TYPE_OAUTH = "oauth2";

        public const string TYPE_ACCOUNT = "2/account";

        public const string TYPE_USERS = "2/users";

        public const string TYPE_FRIENDSHIPS = "2/friendships";

        public const string TYPE_MESSAGES = "2/messages";

        protected Dictionary<string, string> NameValues = new Dictionary<string, string>();

        protected ServiceProxy Proxy = new ServiceProxy();

        #endregion

        #region Method

        public virtual void AddAdditionalParams(Dictionary<string, string> parameters)
        {
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    NameValues[p.Key] = p.Value;
                }
            }
        }

        protected virtual string BuildUrl(string host, string method, Dictionary<string, string> parameters)
        {
            this.NameValues.Clear();

            this.AddAdditionalParams(parameters);

            var sb = new StringBuilder();
            sb.Append(host);
            sb.Append(method);
            sb.Append("?");
            sb.Append((from c in this.NameValues
                       let x = c.Key + "=" + c.Value
                       select x).Aggregate((a, b) => a + "&" + b)
                       );

            return sb.ToString();
        }

        public virtual string GetData(Dictionary<string, string> parameters, Method method = Method.GET)
        {
            var url = this.BuildUrl(HOST, this.MethodName, parameters);

            return this.Proxy.GetData(url, method);
        }

        #endregion
    }
}
