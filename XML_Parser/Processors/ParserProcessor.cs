using System.Data;
using System.Reflection;
using XML_Parser.Etc;

namespace XML_Parser.Processors
{
    public class ParserProcessor : Singleton<ParserProcessor>
    {
        #region " Variables "

        #endregion " Variables End"

        #region " Create & Load & Shown "

        #endregion " Create & Load & Shown End "

        #region " Methods "

        /// <summary>
        /// object 객체의 변수에 DataSet 의 데이터를 넣는 메서드
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ds"></param>
        /// <param name="targetRowNum"></param>
        public void ParserToOBJ(object obj, DataTable dt, int targetRowNum)
        {
            FieldInfo[] infoArr = obj.GetType().GetFields();

            for (int i = 0; i < infoArr.Length; i++)
            {
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    string colName = dt.Columns[col].ColumnName.ToUpper();

                    if (infoArr[i].Name == colName && infoArr[i].FieldType.Name == "String")
                    {
                        string value = dt.Rows[targetRowNum][col].ToString();

                        FieldInfo info = infoArr[i];
                        info.SetValue(obj, value);
                        break;
                    }
                }
            }
        }

        #endregion " Methods End "

        #region " Events "

        #endregion " Events End "
    }
}
