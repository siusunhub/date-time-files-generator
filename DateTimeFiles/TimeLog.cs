using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeFiles
{
    class TimeLog
    {
        public BsonValue _id { get; set; }
        public DateTime CreateDate { get; set; }
    }

}
