using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.AppStores
{
    public class DestApp
    {
        public string Name { get; set; }

        public string AppNo { get; set; }

        public string AppId { get; set; }

        public List<DestTag> TagList { get; set; }
    }
}
