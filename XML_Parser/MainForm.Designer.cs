namespace XML_Parser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiTlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.uiPnl_Top = new System.Windows.Forms.Panel();
            this.uiBtn_Parse = new System.Windows.Forms.Button();
            this.uiBtn_Load = new System.Windows.Forms.Button();
            this.uiTxt_FileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiDGV_Main = new System.Windows.Forms.DataGridView();
            this.uiTlp_Main.SuspendLayout();
            this.uiPnl_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDGV_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTlp_Main
            // 
            this.uiTlp_Main.ColumnCount = 1;
            this.uiTlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTlp_Main.Controls.Add(this.uiPnl_Top, 0, 0);
            this.uiTlp_Main.Controls.Add(this.uiDGV_Main, 0, 1);
            this.uiTlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTlp_Main.Location = new System.Drawing.Point(0, 0);
            this.uiTlp_Main.Name = "uiTlp_Main";
            this.uiTlp_Main.RowCount = 2;
            this.uiTlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.02004F));
            this.uiTlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.97996F));
            this.uiTlp_Main.Size = new System.Drawing.Size(740, 499);
            this.uiTlp_Main.TabIndex = 0;
            // 
            // uiPnl_Top
            // 
            this.uiPnl_Top.Controls.Add(this.uiBtn_Parse);
            this.uiPnl_Top.Controls.Add(this.uiBtn_Load);
            this.uiPnl_Top.Controls.Add(this.uiTxt_FileName);
            this.uiPnl_Top.Controls.Add(this.label1);
            this.uiPnl_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPnl_Top.Location = new System.Drawing.Point(1, 1);
            this.uiPnl_Top.Margin = new System.Windows.Forms.Padding(1);
            this.uiPnl_Top.Name = "uiPnl_Top";
            this.uiPnl_Top.Size = new System.Drawing.Size(738, 47);
            this.uiPnl_Top.TabIndex = 0;
            // 
            // uiBtn_Parse
            // 
            this.uiBtn_Parse.Enabled = false;
            this.uiBtn_Parse.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiBtn_Parse.Location = new System.Drawing.Point(659, 1);
            this.uiBtn_Parse.Name = "uiBtn_Parse";
            this.uiBtn_Parse.Size = new System.Drawing.Size(79, 47);
            this.uiBtn_Parse.TabIndex = 4;
            this.uiBtn_Parse.Text = "Parse";
            this.uiBtn_Parse.UseVisualStyleBackColor = true;
            // 
            // uiBtn_Load
            // 
            this.uiBtn_Load.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uiBtn_Load.Location = new System.Drawing.Point(565, 14);
            this.uiBtn_Load.Name = "uiBtn_Load";
            this.uiBtn_Load.Size = new System.Drawing.Size(67, 23);
            this.uiBtn_Load.TabIndex = 3;
            this.uiBtn_Load.Text = "Load";
            this.uiBtn_Load.UseVisualStyleBackColor = true;
            // 
            // uiTxt_FileName
            // 
            this.uiTxt_FileName.Location = new System.Drawing.Point(107, 15);
            this.uiTxt_FileName.Name = "uiTxt_FileName";
            this.uiTxt_FileName.Size = new System.Drawing.Size(452, 21);
            this.uiTxt_FileName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Name : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiDGV_Main
            // 
            this.uiDGV_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiDGV_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDGV_Main.Location = new System.Drawing.Point(3, 52);
            this.uiDGV_Main.Name = "uiDGV_Main";
            this.uiDGV_Main.RowTemplate.Height = 23;
            this.uiDGV_Main.Size = new System.Drawing.Size(734, 444);
            this.uiDGV_Main.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 499);
            this.Controls.Add(this.uiTlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.uiTlp_Main.ResumeLayout(false);
            this.uiPnl_Top.ResumeLayout(false);
            this.uiPnl_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDGV_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel uiTlp_Main;
        private System.Windows.Forms.Panel uiPnl_Top;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uiBtn_Parse;
        private System.Windows.Forms.Button uiBtn_Load;
        private System.Windows.Forms.TextBox uiTxt_FileName;
        private System.Windows.Forms.DataGridView uiDGV_Main;
    }
}