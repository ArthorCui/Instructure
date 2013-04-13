using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic.SqlGeneration.Schema;

namespace Model.Base
{
    [Serializable]
    public class MobileParam : EntityBase<MobileParam>
    {
        public string IMSI { get; set; }
        public string IMEI { get; set; }
        public string Batch { get; set; }
        public string Pver { get; set; }
        public string Uver { get; set; }
        public string OTAResult { get; set; }
        [SubSonicIgnore]
        public string Os { get; set; }
        [SubSonicIgnore]
        public string Nt { get; set; }
        [SubSonicIgnore]
        public string Lbyver { get; set; }
    }
}
