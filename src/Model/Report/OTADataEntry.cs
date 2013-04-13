using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Report
{
    public class OTADataEntry
    {
        public int Count { get; set; }

        public int CheckCount { get; set; }

        public int DownloadCount { get; set; }

        public StatType Type { get; set; }

        public DateTime DateTime { get; set; }
    }
}
