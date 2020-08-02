namespace MiFare_Programming
{
    partial class MemIDFunc
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
            this.components = new System.ComponentModel.Container();
            this.bReset = new System.Windows.Forms.Button();
            this.bLoadKey = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bQuit = new System.Windows.Forms.Button();
            this.bConnect = new System.Windows.Forms.Button();
            this.bInit = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.cbReader = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.tBinBlk = new System.Windows.Forms.TextBox();
            this.mMsg = new System.Windows.Forms.RichTextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.tBinData = new System.Windows.Forms.TextBox();
            this.bBinRead = new System.Windows.Forms.Button();
            this.bBinUpd = new System.Windows.Forms.Button();
            this.gbBinOps = new System.Windows.Forms.GroupBox();
            this.gbKType = new System.Windows.Forms.GroupBox();
            this.rbKType2 = new System.Windows.Forms.RadioButton();
            this.rbKType1 = new System.Windows.Forms.RadioButton();
            this.AuthBox = new System.Windows.Forms.GroupBox();
            this.lstMemID = new System.Windows.Forms.ListBox();
            this.memberID_dbDataSet = new MemIDFunc_namespace.MemberID_dbDataSet();
            this.memIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.memIDTableAdapter = new MemIDFunc_namespace.MemberID_dbDataSetTableAdapters.MemIDTableAdapter();
            this.lstMemName = new System.Windows.Forms.ListBox();
            this.gbBinOps.SuspendLayout();
            this.gbKType.SuspendLayout();
            this.AuthBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberID_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memIDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(432, 389);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(113, 23);
            this.bReset.TabIndex = 9;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bLoadKey
            // 
            this.bLoadKey.Location = new System.Drawing.Point(169, 43);
            this.bLoadKey.Name = "bLoadKey";
            this.bLoadKey.Size = new System.Drawing.Size(118, 23);
            this.bLoadKey.TabIndex = 3;
            this.bLoadKey.Text = "Load Keys";
            this.bLoadKey.UseVisualStyleBackColor = true;
            this.bLoadKey.Click += new System.EventHandler(this.bLoadKey_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(314, 389);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(102, 23);
            this.bClear.TabIndex = 8;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bQuit
            // 
            this.bQuit.Location = new System.Drawing.Point(557, 389);
            this.bQuit.Name = "bQuit";
            this.bQuit.Size = new System.Drawing.Size(101, 23);
            this.bQuit.TabIndex = 10;
            this.bQuit.Text = "Quit";
            this.bQuit.UseVisualStyleBackColor = true;
            this.bQuit.Click += new System.EventHandler(this.bQuit_Click);
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(191, 75);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(117, 23);
            this.bConnect.TabIndex = 2;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bInit
            // 
            this.bInit.Location = new System.Drawing.Point(191, 46);
            this.bInit.Name = "bInit";
            this.bInit.Size = new System.Drawing.Size(117, 23);
            this.bInit.TabIndex = 1;
            this.bInit.Text = "Initialize";
            this.bInit.UseVisualStyleBackColor = true;
            this.bInit.Click += new System.EventHandler(this.bInit_Click);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(7, 28);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(88, 13);
            this.Label7.TabIndex = 0;
            this.Label7.Text = "Start Block (Dec)";
            // 
            // cbReader
            // 
            this.cbReader.FormattingEnabled = true;
            this.cbReader.Location = new System.Drawing.Point(93, 19);
            this.cbReader.Name = "cbReader";
            this.cbReader.Size = new System.Drawing.Size(216, 21);
            this.cbReader.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 22);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 13);
            this.Label1.TabIndex = 39;
            this.Label1.Text = "Select Reader";
            // 
            // tBinBlk
            // 
            this.tBinBlk.Location = new System.Drawing.Point(101, 25);
            this.tBinBlk.MaxLength = 2;
            this.tBinBlk.Name = "tBinBlk";
            this.tBinBlk.Size = new System.Drawing.Size(33, 20);
            this.tBinBlk.TabIndex = 4;
            // 
            // mMsg
            // 
            this.mMsg.Location = new System.Drawing.Point(315, 22);
            this.mMsg.Name = "mMsg";
            this.mMsg.Size = new System.Drawing.Size(344, 290);
            this.mMsg.TabIndex = 50;
            this.mMsg.Text = "";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(9, 62);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(60, 13);
            this.Label9.TabIndex = 16;
            this.Label9.Text = "Data (Text)";
            // 
            // tBinData
            // 
            this.tBinData.Location = new System.Drawing.Point(12, 78);
            this.tBinData.Name = "tBinData";
            this.tBinData.Size = new System.Drawing.Size(252, 20);
            this.tBinData.TabIndex = 5;
            // 
            // bBinRead
            // 
            this.bBinRead.Location = new System.Drawing.Point(27, 106);
            this.bBinRead.Name = "bBinRead";
            this.bBinRead.Size = new System.Drawing.Size(107, 23);
            this.bBinRead.TabIndex = 6;
            this.bBinRead.Text = "Read Block";
            this.bBinRead.UseVisualStyleBackColor = true;
            this.bBinRead.Click += new System.EventHandler(this.bBinRead_Click);
            // 
            // bBinUpd
            // 
            this.bBinUpd.Location = new System.Drawing.Point(140, 106);
            this.bBinUpd.Name = "bBinUpd";
            this.bBinUpd.Size = new System.Drawing.Size(116, 23);
            this.bBinUpd.TabIndex = 7;
            this.bBinUpd.Text = "Update Block";
            this.bBinUpd.UseVisualStyleBackColor = true;
            this.bBinUpd.Click += new System.EventHandler(this.bBinUpd_Click);
            // 
            // gbBinOps
            // 
            this.gbBinOps.Controls.Add(this.bBinUpd);
            this.gbBinOps.Controls.Add(this.bBinRead);
            this.gbBinOps.Controls.Add(this.tBinData);
            this.gbBinOps.Controls.Add(this.Label9);
            this.gbBinOps.Controls.Add(this.tBinBlk);
            this.gbBinOps.Controls.Add(this.Label7);
            this.gbBinOps.Location = new System.Drawing.Point(12, 277);
            this.gbBinOps.Name = "gbBinOps";
            this.gbBinOps.Size = new System.Drawing.Size(297, 135);
            this.gbBinOps.TabIndex = 45;
            this.gbBinOps.TabStop = false;
            this.gbBinOps.Text = "Binary Block Functions";
            // 
            // gbKType
            // 
            this.gbKType.Controls.Add(this.rbKType2);
            this.gbKType.Controls.Add(this.rbKType1);
            this.gbKType.Location = new System.Drawing.Point(12, 30);
            this.gbKType.Name = "gbKType";
            this.gbKType.Size = new System.Drawing.Size(83, 96);
            this.gbKType.TabIndex = 1;
            this.gbKType.TabStop = false;
            this.gbKType.Text = "Key Type";
            // 
            // rbKType2
            // 
            this.rbKType2.AutoSize = true;
            this.rbKType2.Location = new System.Drawing.Point(16, 53);
            this.rbKType2.Name = "rbKType2";
            this.rbKType2.Size = new System.Drawing.Size(53, 17);
            this.rbKType2.TabIndex = 2;
            this.rbKType2.TabStop = true;
            this.rbKType2.Text = "Key B";
            this.rbKType2.UseVisualStyleBackColor = true;
            // 
            // rbKType1
            // 
            this.rbKType1.AutoSize = true;
            this.rbKType1.Location = new System.Drawing.Point(16, 19);
            this.rbKType1.Name = "rbKType1";
            this.rbKType1.Size = new System.Drawing.Size(53, 17);
            this.rbKType1.TabIndex = 1;
            this.rbKType1.TabStop = true;
            this.rbKType1.Text = "Key A";
            this.rbKType1.UseVisualStyleBackColor = true;
            // 
            // AuthBox
            // 
            this.AuthBox.Controls.Add(this.bLoadKey);
            this.AuthBox.Controls.Add(this.gbKType);
            this.AuthBox.Location = new System.Drawing.Point(12, 117);
            this.AuthBox.Name = "AuthBox";
            this.AuthBox.Size = new System.Drawing.Size(297, 144);
            this.AuthBox.TabIndex = 51;
            this.AuthBox.TabStop = false;
            this.AuthBox.Text = "Authentication Box";
            // 
            // lstMemID
            // 
            this.lstMemID.FormattingEnabled = true;
            this.lstMemID.Location = new System.Drawing.Point(665, 22);
            this.lstMemID.Name = "lstMemID";
            this.lstMemID.Size = new System.Drawing.Size(52, 290);
            this.lstMemID.TabIndex = 52;
            // 
            // memberID_dbDataSet
            // 
            this.memberID_dbDataSet.DataSetName = "MemberID_dbDataSet";
            this.memberID_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // memIDBindingSource
            // 
            this.memIDBindingSource.DataMember = "MemID";
            this.memIDBindingSource.DataSource = this.memberID_dbDataSet;
            // 
            // memIDTableAdapter
            // 
            this.memIDTableAdapter.ClearBeforeFill = true;
            // 
            // lstMemName
            // 
            this.lstMemName.FormattingEnabled = true;
            this.lstMemName.Location = new System.Drawing.Point(723, 22);
            this.lstMemName.Name = "lstMemName";
            this.lstMemName.Size = new System.Drawing.Size(158, 290);
            this.lstMemName.TabIndex = 52;
            // 
            // MiFareCardProg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 424);
            this.Controls.Add(this.lstMemName);
            this.Controls.Add(this.lstMemID);
            this.Controls.Add(this.AuthBox);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bQuit);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.bInit);
            this.Controls.Add(this.cbReader);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.mMsg);
            this.Controls.Add(this.gbBinOps);
            this.Name = "MiFareCardProg";
            this.Text = "Card controller";
            this.Load += new System.EventHandler(this.MiFareCardProg_Load);
            this.gbBinOps.ResumeLayout(false);
            this.gbBinOps.PerformLayout();
            this.gbKType.ResumeLayout(false);
            this.gbKType.PerformLayout();
            this.AuthBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memberID_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memIDBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button bReset;
        internal System.Windows.Forms.Button bLoadKey;
        internal System.Windows.Forms.Button bClear;
        internal System.Windows.Forms.Button bQuit;
        internal System.Windows.Forms.Button bConnect;
        internal System.Windows.Forms.Button bInit;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox cbReader;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox tBinBlk;
        internal System.Windows.Forms.RichTextBox mMsg;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox tBinData;
        internal System.Windows.Forms.Button bBinRead;
        internal System.Windows.Forms.Button bBinUpd;
        internal System.Windows.Forms.GroupBox gbBinOps;
        internal System.Windows.Forms.GroupBox gbKType;
        internal System.Windows.Forms.RadioButton rbKType2;
        internal System.Windows.Forms.RadioButton rbKType1;
        private System.Windows.Forms.GroupBox AuthBox;
        private System.Windows.Forms.ListBox lstMemID;
        private MemIDFunc_namespace.MemberID_dbDataSet memberID_dbDataSet;
        private System.Windows.Forms.BindingSource memIDBindingSource;
        private MemIDFunc_namespace.MemberID_dbDataSetTableAdapters.MemIDTableAdapter memIDTableAdapter;
        private System.Windows.Forms.ListBox lstMemName;
    }
}

