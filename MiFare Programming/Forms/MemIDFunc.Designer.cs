namespace MainUI_namespace.Forms
{
    partial class MainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.bReset = new System.Windows.Forms.Button();
            this.bQuit = new System.Windows.Forms.Button();
            this.bSCard = new System.Windows.Forms.Button();
            this.memberInfo_dbDataSet = new MainUI_namespace.MemberInfo_dbDataSet();
            this.memberInformationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.memberInformationTableAdapter = new MainUI_namespace.MemberInfo_dbDataSetTableAdapters.MemberInformationTableAdapter();
            this.tableAdapterManager = new MainUI_namespace.MemberInfo_dbDataSetTableAdapters.TableAdapterManager();
            this.bAssignCard = new System.Windows.Forms.Button();
            this.bAddMem = new System.Windows.Forms.Button();
            this.bDropIn = new System.Windows.Forms.Button();
            this.bAddCard = new System.Windows.Forms.Button();
            this.bAddPic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.memberInfo_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberInformationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bReset
            // 
            this.bReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bReset.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bReset.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReset.ForeColor = System.Drawing.Color.Blue;
            this.bReset.Location = new System.Drawing.Point(275, 404);
            this.bReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(150, 50);
            this.bReset.TabIndex = 9;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = false;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bQuit
            // 
            this.bQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bQuit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bQuit.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bQuit.ForeColor = System.Drawing.Color.Blue;
            this.bQuit.Location = new System.Drawing.Point(119, 404);
            this.bQuit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bQuit.Name = "bQuit";
            this.bQuit.Size = new System.Drawing.Size(150, 50);
            this.bQuit.TabIndex = 10;
            this.bQuit.Text = "Quit";
            this.bQuit.UseVisualStyleBackColor = false;
            this.bQuit.Click += new System.EventHandler(this.bQuit_Click);
            // 
            // bSCard
            // 
            this.bSCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSCard.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bSCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bSCard.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSCard.ForeColor = System.Drawing.Color.Blue;
            this.bSCard.Location = new System.Drawing.Point(202, 193);
            this.bSCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bSCard.Name = "bSCard";
            this.bSCard.Size = new System.Drawing.Size(150, 50);
            this.bSCard.TabIndex = 9;
            this.bSCard.Text = "Check In/Out";
            this.bSCard.UseVisualStyleBackColor = false;
            this.bSCard.Click += new System.EventHandler(this.bSCard_Click);
            // 
            // memberInfo_dbDataSet
            // 
            this.memberInfo_dbDataSet.DataSetName = "MemberInfo_dbDataSet";
            this.memberInfo_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // memberInformationBindingSource
            // 
            this.memberInformationBindingSource.DataMember = "MemberInformation";
            this.memberInformationBindingSource.DataSource = this.memberInfo_dbDataSet;
            // 
            // memberInformationTableAdapter
            // 
            this.memberInformationTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.MemberInformationTableAdapter = this.memberInformationTableAdapter;
            this.tableAdapterManager.UpdateOrder = MainUI_namespace.MemberInfo_dbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bAssignCard
            // 
            this.bAssignCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAssignCard.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bAssignCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bAssignCard.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAssignCard.ForeColor = System.Drawing.Color.Blue;
            this.bAssignCard.Location = new System.Drawing.Point(202, 324);
            this.bAssignCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bAssignCard.Name = "bAssignCard";
            this.bAssignCard.Size = new System.Drawing.Size(150, 50);
            this.bAssignCard.TabIndex = 9;
            this.bAssignCard.Text = "Assign Card";
            this.bAssignCard.UseVisualStyleBackColor = false;
            this.bAssignCard.Click += new System.EventHandler(this.bAssignCard_Click);
            // 
            // bAddMem
            // 
            this.bAddMem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddMem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bAddMem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bAddMem.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddMem.ForeColor = System.Drawing.Color.Blue;
            this.bAddMem.Location = new System.Drawing.Point(202, 259);
            this.bAddMem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bAddMem.Name = "bAddMem";
            this.bAddMem.Size = new System.Drawing.Size(150, 50);
            this.bAddMem.TabIndex = 9;
            this.bAddMem.Text = "Add Member";
            this.bAddMem.UseVisualStyleBackColor = false;
            this.bAddMem.Click += new System.EventHandler(this.bAddMem_Click);
            // 
            // bDropIn
            // 
            this.bDropIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bDropIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bDropIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bDropIn.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDropIn.ForeColor = System.Drawing.Color.Blue;
            this.bDropIn.Location = new System.Drawing.Point(202, 126);
            this.bDropIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bDropIn.Name = "bDropIn";
            this.bDropIn.Size = new System.Drawing.Size(150, 50);
            this.bDropIn.TabIndex = 9;
            this.bDropIn.Text = "Drop In";
            this.bDropIn.UseVisualStyleBackColor = false;
            this.bDropIn.Click += new System.EventHandler(this.bDropIn_Click);
            // 
            // bAddCard
            // 
            this.bAddCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddCard.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bAddCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bAddCard.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddCard.ForeColor = System.Drawing.Color.Blue;
            this.bAddCard.Location = new System.Drawing.Point(394, 324);
            this.bAddCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bAddCard.Name = "bAddCard";
            this.bAddCard.Size = new System.Drawing.Size(150, 50);
            this.bAddCard.TabIndex = 9;
            this.bAddCard.Text = "Add Card";
            this.bAddCard.UseVisualStyleBackColor = false;
            this.bAddCard.Click += new System.EventHandler(this.bADDCard_Click);
            // 
            // bAddPic
            // 
            this.bAddPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddPic.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bAddPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bAddPic.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAddPic.ForeColor = System.Drawing.Color.Blue;
            this.bAddPic.Location = new System.Drawing.Point(394, 259);
            this.bAddPic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bAddPic.Name = "bAddPic";
            this.bAddPic.Size = new System.Drawing.Size(150, 50);
            this.bAddPic.TabIndex = 9;
            this.bAddPic.Text = "Add Picture";
            this.bAddPic.UseVisualStyleBackColor = false;
            this.bAddPic.Click += new System.EventHandler(this.bAddPic_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImage = global::MainUI_namespace.Properties.Resources.Logo1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(556, 465);
            this.Controls.Add(this.bDropIn);
            this.Controls.Add(this.bAddMem);
            this.Controls.Add(this.bAddCard);
            this.Controls.Add(this.bAddPic);
            this.Controls.Add(this.bAssignCard);
            this.Controls.Add(this.bSCard);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.bQuit);
            this.Font = new System.Drawing.Font("Malgun Gothic Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.IndianRed;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barriere Gym and Fitness Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MiFareCardProg_Load);
            this.SizeChanged += new System.EventHandler(this.UI_OnSizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.memberInfo_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberInformationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button bReset;
        internal System.Windows.Forms.Button bQuit;
        internal System.Windows.Forms.Button bSCard;
        private MainUI_namespace.MemberInfo_dbDataSet memberInfo_dbDataSet;
        private System.Windows.Forms.BindingSource memberInformationBindingSource;
        private MainUI_namespace.MemberInfo_dbDataSetTableAdapters.MemberInformationTableAdapter memberInformationTableAdapter;
        private MainUI_namespace.MemberInfo_dbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        internal System.Windows.Forms.Button bAssignCard;
        internal System.Windows.Forms.Button bAddMem;
        internal System.Windows.Forms.Button bDropIn;
        internal System.Windows.Forms.Button bAddCard;
        internal System.Windows.Forms.Button bAddPic;
    }
}

