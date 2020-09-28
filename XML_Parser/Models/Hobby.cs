using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML_Parser.Processors;

namespace XML_Parser.Models
{
    class Hobby
    {
        public string STD_NO = string.Empty;
        public string HOBBY_ID = string.Empty;
        public string HOBBY_NAME = string.Empty;

        public Hobby(DataTable dt, int row)
        {
            ParserProcessor.Instance.ParserToOBJ(this, dt, row);
        }
    }
}
