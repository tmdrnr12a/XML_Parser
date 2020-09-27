using System.Data;
using System.Reflection;

namespace XML_Parser.Processors
{
    class ParserProcessor
    {
        /// <summary>
        /// object 객체의 변수에 DataSet 의 데이터를 넣는 메서드
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ds"></param>
        /// <param name="targetRowNum"></param>
        public static void ParserToOBJ(object obj, DataSet ds, int targetRowNum)
        {
            FieldInfo[] infoArr = obj.GetType().GetFields();

            for (int i = 0; i < infoArr.Length; i++)
            {
                bool goFirst = false;

                for (int t = 0; t < ds.Tables.Count; t++)
                {
                    for (int col = 0; col < ds.Tables[t].Columns.Count; col++)
                    {
                        string colName = ds.Tables[t].Columns[col].ColumnName.ToUpper();

                        if (infoArr[i].Name == colName && infoArr[i].FieldType.Name == "String")
                        {
                            string value = ds.Tables[t].Rows[targetRowNum][col].ToString();

                            FieldInfo info = infoArr[i];
                            info.SetValue(obj, value);
                            goFirst = true;
                            break;
                        }
                    }

                    if (goFirst == true)
                        break;
                }
            }
        }
    }
}
