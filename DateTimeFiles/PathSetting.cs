using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeFiles
{
    class PathSetting
    {
        public BsonValue _id { get; set; }

        public string path { get; set; }
        public int no { get; set; }

    }
}
