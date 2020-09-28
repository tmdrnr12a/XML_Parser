using System.Data;
using XML_Parser.Processors;

namespace XML_Parser.Models
{
    class Hobby
    {
        #region " Variables "

        public string STD_NO = string.Empty;
        public string HOBBY_ID = string.Empty;
        public string HOBBY_NAME = string.Empty;

        #endregion " Variables End"

        #region " Create & Load & Shown "

        public Hobby(DataTable dt, int row)
        {
            ParserProcessor.Instance.ParserToOBJ(this, dt, row);
        }

        #endregion " Create & Load & Shown End "

        #region " Methods "

        #endregion " Methods End "

        #region " Events "

        #endregion " Events End "
    }
}
