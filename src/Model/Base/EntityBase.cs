using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic.SqlGeneration.Schema;

namespace Model.Base
{
    public abstract class EntityBase<T> : ModelBase
    {
        [SubSonicPrimaryKey]
        public virtual int Id { get; set; }
    }
}
