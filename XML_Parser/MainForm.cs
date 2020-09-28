using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML_Parser.Managers;
using XML_Parser.Models;
using XML_Parser.Processors;

namespace XML_Parser
{
    public partial class MainForm : Form
    {
        #region " Variables "

        // Connect to DB
        private BackgroundWorker ConnectWorker = null;

        #endregion " Variables End"

        #region " Create & Load & Shown "

        public MainForm()
        {
            InitializeComponent();

            this.Shown += MainForm_Shown;

            uiBtn_Load.Click += UiBtn_Load_Click;
            uiBtn_Parse.Click += UiBtn_Parse_Click;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitDataGridView();

            ConnectDB();
        }

        #endregion " Create & Load & Shown End "

        #region " Methods "

        private void InitDataGridView()
        {
            uiDGV_Main.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            uiDGV_Main.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            uiDGV_Main.AutoResizeColumns();
            uiDGV_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Connect to DB 
        /// </summary>
        private void ConnectDB()
        {
            if (this.ConnectWorker == null)
            {
                this.ConnectWorker = new BackgroundWorker();
                this.ConnectWorker.DoWork += ConnectWorker_DoWork;
                this.ConnectWorker.RunWorkerCompleted += ConnectWorker_RunWorkerCompleted;
            }

            this.ConnectWorker.RunWorkerAsync();
        }

        #endregion " Methods End "

        #region " Events "

        /// <summary>
        /// Try to connect DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (MssqlManager.Instance.GetConnection() == true)
                        break;

                    Thread.Sleep(1000);
                }
                catch { }
            }
        }

        private void ConnectWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            uiBtn_Parse.Invoke(new MethodInvoker(delegate ()
            {
                uiBtn_Parse.Enabled = true;
            }));

#if DEBUG
            uiTxt_FileName.Text = $@"{Application.StartupPath}\References\Sample.xml";
#endif
        }

        private void UiBtn_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                Title = "Select a XML File"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
                uiTxt_FileName.Text = ofd.FileName;
        }

        private void UiBtn_Parse_Click(object sender, EventArgs e)
        {
            string fileName = uiTxt_FileName.Text;

            if (File.Exists(fileName) == false)
            {
                MessageBox.Show("File does not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataSet xmlDs = new DataSet();

            try
            {
                xmlDs.ReadXml(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (xmlDs != null && xmlDs.Tables.Count > 0 && xmlDs.Tables[0].Rows.Count > 0)
            {
                // ParserProcessor 내 함수를 이용해서 Model 객체에 ds 정보를 세팅하고
                StudentList stdList = new StudentList(xmlDs);

                // DatabaseProcessor 내 함수를 이용해서 DB 에 입력
                //DatabaseProcessor.Instance.InsertData(stdList);

                // DB 에 입력된 내용 조회해서 Datasource 로 보여주기
                uiDGV_Main.DataSource = DatabaseProcessor.Instance.GetData();

                //uiDGV_Main.AutoResizeColumns();
                //uiDGV_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        #endregion " Events End "
    }
}
