﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.iTunesApp
{
    public class iTunes
    {
        public string Author { get; set; }
        public string Subtitle { get; set; }
        public string Summary { get; set; }
        public Owner Owner { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Explicit { get; set; }
        public string Keywords { get; set; }

    }
}
