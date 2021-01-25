namespace MainUI_namespace.Forms
{
    partial class EditMemberForm
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
            this.tParamVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbParam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lDes = new System.Windows.Forms.Label();
            this.bSearch = new System.Windows.Forms.Button();
            this.bAssign = new System.Windows.Forms.Button();
            this.lvMember = new System.Windows.Forms.ListView();
            this.CustomerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DOB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MemID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PhoneNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pBox = new AForge.Controls.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tParamVal
            // 
            this.tParamVal.Location = new System.Drawing.Point(354, 118);
            this.tParamVal.Margin = new System.Windows.Forms.Padding(5);
            this.tParamVal.Name = "tParamVal";
            this.tParamVal.Size = new System.Drawing.Size(234, 27);
            this.tParamVal.TabIndex = 0;
            this.tParamVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValueRestriction);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Member Search Value";
            // 
            // cbParam
            // 
            this.cbParam.FormattingEnabled = true;
            this.cbParam.Location = new System.Drawing.Point(113, 118);
            this.cbParam.Name = "cbParam";
            this.cbParam.Size = new System.Drawing.Size(121, 28);
            this.cbParam.TabIndex = 2;
            this.cbParam.SelectedIndexChanged += new System.EventHandler(this.SearchParamSelected);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search Parameter";
            // 
            // lDes
            // 
            this.lDes.AutoSize = true;
            this.lDes.Location = new System.Drawing.Point(358, 165);
            this.lDes.Name = "lDes";
            this.lDes.Size = new System.Drawing.Size(46, 22);
            this.lDes.TabIndex = 3;
            this.lDes.Text = "lDes";
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(596, 118);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(109, 28);
            this.bSearch.TabIndex = 4;
            this.bSearch.Text = "Search";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bAssign
            // 
            this.bAssign.Location = new System.Drawing.Point(113, 373);
            this.bAssign.Name = "bAssign";
            this.bAssign.Size = new System.Drawing.Size(109, 28);
            this.bAssign.TabIndex = 4;
            this.bAssign.Text = "Assign";
            this.bAssign.UseVisualStyleBackColor = true;
            this.bAssign.Click += new System.EventHandler(this.bAssign_Click);
            // 
            // lvMember
            // 
            this.lvMember.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CustomerID,
            this.MemName,
            this.DOB,
            this.MemID,
            this.PhoneNum});
            this.lvMember.FullRowSelect = true;
            this.lvMember.GridLines = true;
            this.lvMember.HideSelection = false;
            this.lvMember.Location = new System.Drawing.Point(86, 190);
            this.lvMember.MultiSelect = false;
            this.lvMember.Name = "lvMember";
            this.lvMember.Size = new System.Drawing.Size(619, 143);
            this.lvMember.TabIndex = 5;
            this.lvMember.UseCompatibleStateImageBehavior = false;
            this.lvMember.View = System.Windows.Forms.View.Details;
            this.lvMember.SelectedIndexChanged += new System.EventHandler(this.LV_RowSelect);
            // 
            // CustomerID
            // 
            this.CustomerID.Text = "Id";
            // 
            // MemName
            // 
            this.MemName.Text = "Member Name";
            this.MemName.Width = 150;
            // 
            // DOB
            // 
            this.DOB.Text = "Date of Birth";
            this.DOB.Width = 120;
            // 
            // MemID
            // 
            this.MemID.Text = "Identification Number";
            this.MemID.Width = 130;
            // 
            // PhoneNum
            // 
            this.PhoneNum.Text = "Phone Number";
            this.PhoneNum.Width = 135;
            // 
            // pBox
            // 
            this.pBox.Image = null;
            this.pBox.Location = new System.Drawing.Point(774, 193);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(292, 139);
            this.pBox.TabIndex = 6;
            this.pBox.TabStop = false;
            // 
            // CardMemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 466);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.lvMember);
            this.Controls.Add(this.bAssign);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.lDes);
            this.Controls.Add(this.cbParam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tParamVal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "CardMemForm";
            this.Text = "Assign Card";
            this.Load += new System.EventHandler(this.CardMemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tParamVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbParam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lDes;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bAssign;
        private System.Windows.Forms.ListView lvMember;
        private System.Windows.Forms.ColumnHeader MemName;
        private System.Windows.Forms.ColumnHeader DOB;
        private System.Windows.Forms.ColumnHeader MemID;
        private System.Windows.Forms.ColumnHeader PhoneNum;
        private System.Windows.Forms.ColumnHeader CustomerID;
        private AForge.Controls.PictureBox pBox;
    }
}