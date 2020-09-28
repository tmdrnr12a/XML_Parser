using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML_Parser.Etc;
using XML_Parser.Managers;
using XML_Parser.Models;

namespace XML_Parser.Processors
{
    class DatabaseProcessor : Singleton<DatabaseProcessor>
    {
        #region " Variables "

        #endregion " Variables End"

        #region " Create & Load & Shown "

        #endregion " Create & Load & Shown End "

        #region " Methods "

        public void InsertData(StudentList stdList)
        {
            InsertStudentData(stdList);
            InsertHobbyData(stdList);
        }

        private void InsertStudentData(StudentList stdList)
        {
            string headerQuery =
@"
INSERT INTO PSK_DB.DBO.STUDENT_INFO(STD_NO, STD_NAME, STD_AGE, STD_GRADE, STD_MAJOR)
VALUES
";
            StringBuilder query = new StringBuilder();
            query.Clear();

            query.AppendFormat(headerQuery);

            for (int i = 0; i < stdList.STD_LIST.Count; i++)
            {
                query.AppendFormat("\t");
                query.AppendFormat("(");
                query.AppendFormat("'{0}', ", stdList.STD_LIST[i].STD_NO);
                query.AppendFormat("'{0}', ", stdList.STD_LIST[i].STD_NAME);
                query.AppendFormat("'{0}', ", stdList.STD_LIST[i].STD_AGE);
                query.AppendFormat("'{0}', ", stdList.STD_LIST[i].STD_GRADE);
                query.AppendFormat("'{0}' ", stdList.STD_LIST[i].STD_MAJOR);
                query.AppendFormat(")");

                // 100개 단위로 입력
                if ((i % 100 == 99) || (i == stdList.STD_LIST.Count - 1))
                {
                    query = query.Replace("*", "");

                    try
                    {
                        MssqlManager.Instance.ExecuteNonQuery(query.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    query.Clear();
                    query.AppendFormat(headerQuery);
                }
                else
                {
                    query.AppendFormat(", \n");
                }
            }
        }

        private void InsertHobbyData(StudentList stdList)
        {
            string headerQuery =
@"
INSERT INTO PSK_DB.DBO.HOBBY_INFO(STD_NO, HOBBY_ID, HOBBY_NAME)
VALUES
";
            StringBuilder query = new StringBuilder();
            query.Clear();

            query.AppendFormat(headerQuery);

            for (int i = 0; i < stdList.STD_LIST.Count; i++)
            {
                for (int k = 0; k < stdList.STD_LIST[i].HOBBY_LIST.Count; k++)
                {
                    string stdNo = stdList.STD_LIST[i].HOBBY_LIST[k].STD_NO;
                    string hobbyId = stdList.STD_LIST[i].HOBBY_LIST[k].HOBBY_ID;
                    string hobbyName = stdList.STD_LIST[i].HOBBY_LIST[k].HOBBY_NAME;

                    if (String.IsNullOrEmpty(hobbyId) && String.IsNullOrEmpty(hobbyName))
                        continue;

                    query.AppendFormat("\t");
                    query.AppendFormat("(");
                    query.AppendFormat("'{0}', ", stdNo);
                    query.AppendFormat("'{0}', ", hobbyId);
                    query.AppendFormat("'{0}' ", hobbyName);
                    query.AppendFormat(")");

                    // 100개 단위로 입력
                    if ((k % 100 == 99) || (k == stdList.STD_LIST[i].HOBBY_LIST.Count - 1))
                    {
                        query = query.Replace("*", "");

                        try
                        {
                            MssqlManager.Instance.ExecuteNonQuery(query.ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        query.Clear();
                        query.AppendFormat(headerQuery);
                    }
                    else
                    {
                        query.AppendFormat(", \n");
                    }
                }
            }
        }

        public DataTable GetData()
        {
            string query =
@"
SELECT 
    S.STD_NO, 
    S.STD_NAME,
    S.STD_AGE,
    S.STD_GRADE,
    S.STD_MAJOR,
    STUFF(
			(SELECT ', ' + HOBBY_NAME 
			 FROM PSK_DB.DBO.HOBBY_INFO 
			 WHERE STD_NO = S.STD_NO 
			 FOR XML PATH('')), 1, 1, ''
	) AS HOBBIES	
FROM PSK_DB.DBO.STUDENT_INFO S
";
            DataSet ds = new DataSet();

            try
            {
                MssqlManager.Instance.ExecuteDsQuery(ds, query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0];
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        #endregion " Methods End "

        #region " Events "

        #endregion " Events End "

    }
}
