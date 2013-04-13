using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LBS
{
    public class CellInfo
    {
        public string cid; //表示基站号
        public string lac; //区域编号
        public string mcc; //国家编号
        public string mnc; //移动网络编号

        public string CID
        { get { return cid; } set { cid = value; } }
        public string LAC
        { get { return lac; } set { lac = value; } }
        public string MCC
        { get { return mcc; } set { mcc = value; } }
        public string MNC
        { get { return mnc; } set { mnc = value; } }
    }
}
