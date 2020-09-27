using System;
using System.Data;

using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace XML_Parser.Managers
{
    public sealed class MssqlManager
    {
        private enum ExcuteResult { Fail = -2, Success = -1 };

        public string ConnectionString = string.Empty;

        public string IP { get; private set; }
        public string LastException { get; private set; }

        public SqlConnection Connection { get; private set; }

        private static MssqlManager instance;

        public static MssqlManager Instance
        {
            get
            {
                if (instance == null) instance = new MssqlManager();

                return instance;
            }
        }

        private SqlCommand _sqlCmd = null;

        public MssqlManager()
        {
            _sqlCmd = new SqlCommand();
        }

        public bool GetConnection()
        {
            try
            {
                if (ConnectionString == string.Empty)
                    SetConnectionString();

                Connection = new SqlConnection(ConnectionString);

                Connection.Open();
            }
            catch (Exception ex)
            {
                LastException = ex.ToString();

                return false;
            }

            if (Connection.State == ConnectionState.Open)
                return true;
            else
                return false;
        }

        public int ExecuteNonQuery(string query)
        {
            lock (this)
            {
                return Execute_NonQuery(query);
            }
        }

        public bool HasRows(string query)
        {
            lock (this)
            {
                SqlDataReader result = ExecuteReader(query);

                return result.HasRows;
            }
        }

        public SqlDataReader ExecuteReaderQuery(string query)
        {
            lock (this)
            {
                SqlDataReader result = ExecuteReader(query);

                return result;
            }
        }

        public DataSet ExecuteDsQuery(DataSet ds, string query)
        {
            ds.Reset();

            lock (this)
            {
                //dbLoger.WriteLog(LogType.Inform, string.Format("ExecuteDsQuery - {0}", query));

                return ExecuteDataAdt(ds, query);
            }
        }

        public DataSet ExecuteProcedure(DataSet ds, string procName, params string[] pValues)
        {
            lock (this)
            {
                return ExecuteProcedureAdt(ds, procName, pValues);
            }
        }

        public void CancelQuery()
        {
            _sqlCmd.Cancel();
        }

        public void Close()
        {
            Connection.Close();
        }

        #region private..........................................................

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        private bool CheckConnection()
        {
            bool result = true;

            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == false)
            {
                this.LastException = "네트워크 연결이 끊어졌습니다.";
                System.Windows.Forms.MessageBox.Show(this.LastException, "Error");
                result = false;
            }
            else if (this.Connection == null || this.Connection.State == ConnectionState.Closed)
            {
                result = this.GetConnection();
            }

            return result;
        }

        private void SetConnectionString()
        {
            string ip = FileManager.GetValueString("DATABASE", "IP", "");
            string user = FileManager.GetValueString("DATABASE", "USER", "");
            string pwd = FileManager.GetValueString("DATABASE", "PWD", "");
            string dbName = FileManager.GetValueString("DATABASE", "DB_NAME", "");

            string dataSource = string.Format(@"Data Source={0};Database={1};User Id={2};Password={3}", ip, dbName, user, pwd);

            this.IP = ip;
            this.ConnectionString = dataSource;
        }

        private int Execute_NonQuery(string query)
        {
            int result = (int)ExcuteResult.Fail;

            try
            {
                _sqlCmd = new SqlCommand
                {
                    Connection = this.Connection,
                    CommandText = query
                };
                result = _sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LastException = ex.ToString();

                if (CheckConnection() == false)
                    return result;
            }

            return result;
        }

        private SqlDataReader ExecuteReader(string query)
        {
            SqlDataReader result = null;

            try
            {
                _sqlCmd = new SqlCommand
                {
                    Connection = this.Connection,
                    CommandText = query
                };
                result = _sqlCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                LastException = ex.ToString();

                if (CheckConnection() == false)
                    return result;
            }

            return result;
        }

        private DataSet ExecuteDataAdt(DataSet ds, string query)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter
                {
                    SelectCommand = _sqlCmd
                };
                cmd.SelectCommand.Connection = this.Connection;
                cmd.SelectCommand.CommandText = query;
                cmd.Fill(ds);
            }
            catch (Exception ex)
            {
                LastException = ex.Message.ToString();

                if (CheckConnection() == false)
                    return null;
            }

            return ds;
        }

        private DataSet ExecuteProcedureAdt(DataSet ds, string query, params string[] values)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = _sqlCmd
                };
                adapter.SelectCommand.CommandText = query;
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Connection = this.Connection;

                for (int i = 0; i < values.Length; ++i)
                {
                    adapter.SelectCommand.Parameters.Add(values[i]);
                    //adapter.SelectCommand.Parameters.Add("params", values[i]);
                }

                adapter.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                this.LastException = ex.ToString();

                if (CheckConnection() == false)
                    return null;
            }

            return ds;
        }

        #endregion private..................................................................
    }
}
