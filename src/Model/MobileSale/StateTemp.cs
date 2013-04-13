using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic.SqlGeneration.Schema;

namespace Model.MobileSale
{
    [Serializable]
    [SubSonicTableNameOverride("State_Temp")]
    public class StateTemp : State
    {
        public int T_Id { get; set; }
    }
}
