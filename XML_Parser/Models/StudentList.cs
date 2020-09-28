using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML_Parser.Processors;

namespace XML_Parser.Models
{
    class StudentList
    {
        public List<Student> STD_LIST = new List<Student>();

        public StudentList(DataSet ds)
        {
            SetList(ds);
        }

        private void SetList(DataSet ds)
        {
            for (int row = 0; row < ds.Tables["STD_INFO"].Rows.Count; row++)
            {
                Student std = new Student(ds, row);
                this.STD_LIST.Add(std);
            }
        }
    }
}
