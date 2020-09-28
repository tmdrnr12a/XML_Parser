using System.Collections.Generic;
using System.Data;

namespace XML_Parser.Models
{
    class StudentList
    {
        #region " Variables "

        public List<Student> STD_LIST = new List<Student>();

        #endregion " Variables End"

        #region " Create & Load & Shown "
        public StudentList(DataSet ds)
        {
            SetList(ds);
        }

        #endregion " Create & Load & Shown End "

        #region " Methods "

        private void SetList(DataSet ds)
        {
            for (int row = 0; row < ds.Tables["STD_INFO"].Rows.Count; row++)
            {
                Student std = new Student(ds, row);
                this.STD_LIST.Add(std);
            }
        }

        #endregion " Methods End "

        #region " Events "

        #endregion " Events End "
    }
}
