using System.Collections.Generic;
using System.Data;
using XML_Parser.Processors;

namespace XML_Parser.Models
{
    class Student
    {
        #region " Variables "

        public string STD_ID = string.Empty;
        public string STD_NO = string.Empty;
        public string STD_NAME = string.Empty;
        public string STD_AGE = string.Empty;
        public string STD_GRADE = string.Empty;
        public string STD_MAJOR = string.Empty;

        public List<Hobby> HOBBY_LIST = new List<Hobby>();

        #endregion " Variables End"

        #region " Create & Load & Shown "

        public Student(DataSet ds, int id)
        {
            DataTable stdDt = ds.Tables["STD_INFO"];
            ParserProcessor.Instance.ParserToOBJ(this, stdDt, id);

            this.STD_ID = id.ToString();
            SetList(ds, this.STD_ID);
        }

        #endregion " Create & Load & Shown End "

        #region " Methods "

        private void SetList(DataSet ds, string stdId)
        {
            DataTable dt = ds.Tables["HOBBY_INFO"];

            for (int row = 0; row < dt.Rows.Count; row++)
            {
                string hStdID = dt.Rows[row]["STD_INFO_Id"].ToString();

                if (hStdID != stdId)
                    continue;

                Hobby hobby = new Hobby(dt, row)
                {
                    STD_NO = this.STD_NO
                };
                this.HOBBY_LIST.Add(hobby);
            }
        }

        #endregion " Methods End "

        #region " Events "

        #endregion " Events End "
    }
}
