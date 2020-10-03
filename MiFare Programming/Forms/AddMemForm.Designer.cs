namespace MemIDFunc_namespace
{
    partial class AddMemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMemForm));
            this.lName = new System.Windows.Forms.Label();
            this.lPhoneNum = new System.Windows.Forms.Label();
            this.lMemDe = new System.Windows.Forms.Label();
            this.bAddPic = new System.Windows.Forms.Button();
            this.lAddress = new System.Windows.Forms.Label();
            this.tName = new System.Windows.Forms.TextBox();
            this.tPhoneNum = new System.Windows.Forms.TextBox();
            this.tAddress = new System.Windows.Forms.TextBox();
            this.bFinish = new System.Windows.Forms.Button();
            this.ckBUnderAge = new System.Windows.Forms.CheckBox();
            this.cbMemDetail = new System.Windows.Forms.ComboBox();
            this.lMemEmail = new System.Windows.Forms.Label();
            this.tMemEmail = new System.Windows.Forms.TextBox();
            this.tParentName = new System.Windows.Forms.TextBox();
            this.tParentPhone = new System.Windows.Forms.TextBox();
            this.lParentName = new System.Windows.Forms.Label();
            this.lParentPhone = new System.Windows.Forms.Label();
            this.tParentEmail = new System.Windows.Forms.TextBox();
            this.lParentEmail = new System.Windows.Forms.Label();
            this.gParentInfo = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tEMERel = new System.Windows.Forms.TextBox();
            this.tEMEName = new System.Windows.Forms.TextBox();
            this.tEMEPhone = new System.Windows.Forms.TextBox();
            this.lEName = new System.Windows.Forms.Label();
            this.lEPhone = new System.Windows.Forms.Label();
            this.lERel = new System.Windows.Forms.Label();
            this.gBMain = new System.Windows.Forms.GroupBox();
            this.gParentInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gBMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(5, 45);
            this.lName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(57, 22);
            this.lName.TabIndex = 0;
            this.lName.Text = "Name";
            // 
            // lPhoneNum
            // 
            this.lPhoneNum.AutoSize = true;
            this.lPhoneNum.Location = new System.Drawing.Point(5, 83);
            this.lPhoneNum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lPhoneNum.Name = "lPhoneNum";
            this.lPhoneNum.Size = new System.Drawing.Size(130, 22);
            this.lPhoneNum.TabIndex = 0;
            this.lPhoneNum.Text = "Phone Number";
            // 
            // lMemDe
            // 
            this.lMemDe.AutoSize = true;
            this.lMemDe.Location = new System.Drawing.Point(5, 198);
            this.lMemDe.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lMemDe.Name = "lMemDe";
            this.lMemDe.Size = new System.Drawing.Size(158, 22);
            this.lMemDe.TabIndex = 0;
            this.lMemDe.Text = "Membership Detail";
            // 
            // bAddPic
            // 
            this.bAddPic.Location = new System.Drawing.Point(302, 268);
            this.bAddPic.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.bAddPic.Name = "bAddPic";
            this.bAddPic.Size = new System.Drawing.Size(125, 35);
            this.bAddPic.TabIndex = 8;
            this.bAddPic.Text = "Add Picture";
            this.bAddPic.UseVisualStyleBackColor = true;
            this.bAddPic.Click += new System.EventHandler(this.bAddPic_Click);
            // 
            // lAddress
            // 
            this.lAddress.AutoSize = true;
            this.lAddress.Location = new System.Drawing.Point(5, 122);
            this.lAddress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lAddress.Name = "lAddress";
            this.lAddress.Size = new System.Drawing.Size(76, 22);
            this.lAddress.TabIndex = 0;
            this.lAddress.Text = "Address";
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(135, 40);
            this.tName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(289, 27);
            this.tName.TabIndex = 1;
            // 
            // tPhoneNum
            // 
            this.tPhoneNum.Location = new System.Drawing.Point(135, 78);
            this.tPhoneNum.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tPhoneNum.Name = "tPhoneNum";
            this.tPhoneNum.Size = new System.Drawing.Size(289, 27);
            this.tPhoneNum.TabIndex = 2;
            // 
            // tAddress
            // 
            this.tAddress.Location = new System.Drawing.Point(135, 117);
            this.tAddress.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tAddress.Name = "tAddress";
            this.tAddress.Size = new System.Drawing.Size(289, 27);
            this.tAddress.TabIndex = 3;
            // 
            // bFinish
            // 
            this.bFinish.Enabled = false;
            this.bFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFinish.Location = new System.Drawing.Point(350, 358);
            this.bFinish.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.bFinish.Name = "bFinish";
            this.bFinish.Size = new System.Drawing.Size(305, 62);
            this.bFinish.TabIndex = 9;
            this.bFinish.Text = "Finish";
            this.bFinish.UseVisualStyleBackColor = true;
            this.bFinish.Click += new System.EventHandler(this.bFinish_Click);
            // 
            // ckBUnderAge
            // 
            this.ckBUnderAge.AutoSize = true;
            this.ckBUnderAge.Location = new System.Drawing.Point(120, 2);
            this.ckBUnderAge.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ckBUnderAge.Name = "ckBUnderAge";
            this.ckBUnderAge.Size = new System.Drawing.Size(173, 26);
            this.ckBUnderAge.TabIndex = 0;
            this.ckBUnderAge.Text = "Under 19 year-old";
            this.ckBUnderAge.UseVisualStyleBackColor = true;
            this.ckBUnderAge.CheckedChanged += new System.EventHandler(this.UnderAgeCheckChanged);
            // 
            // cbMemDetail
            // 
            this.cbMemDetail.FormattingEnabled = true;
            this.cbMemDetail.Location = new System.Drawing.Point(172, 194);
            this.cbMemDetail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbMemDetail.Name = "cbMemDetail";
            this.cbMemDetail.Size = new System.Drawing.Size(252, 28);
            this.cbMemDetail.TabIndex = 5;
            // 
            // lMemEmail
            // 
            this.lMemEmail.AutoSize = true;
            this.lMemEmail.Location = new System.Drawing.Point(5, 160);
            this.lMemEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lMemEmail.Name = "lMemEmail";
            this.lMemEmail.Size = new System.Drawing.Size(123, 22);
            this.lMemEmail.TabIndex = 0;
            this.lMemEmail.Text = "Member Email";
            // 
            // tMemEmail
            // 
            this.tMemEmail.Location = new System.Drawing.Point(135, 155);
            this.tMemEmail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tMemEmail.Name = "tMemEmail";
            this.tMemEmail.Size = new System.Drawing.Size(289, 27);
            this.tMemEmail.TabIndex = 4;
            // 
            // tParentName
            // 
            this.tParentName.Location = new System.Drawing.Point(213, 32);
            this.tParentName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tParentName.Name = "tParentName";
            this.tParentName.Size = new System.Drawing.Size(289, 27);
            this.tParentName.TabIndex = 0;
            // 
            // tParentPhone
            // 
            this.tParentPhone.Location = new System.Drawing.Point(213, 71);
            this.tParentPhone.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tParentPhone.Name = "tParentPhone";
            this.tParentPhone.Size = new System.Drawing.Size(289, 27);
            this.tParentPhone.TabIndex = 1;
            // 
            // lParentName
            // 
            this.lParentName.AutoSize = true;
            this.lParentName.Location = new System.Drawing.Point(17, 32);
            this.lParentName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lParentName.Name = "lParentName";
            this.lParentName.Size = new System.Drawing.Size(115, 22);
            this.lParentName.TabIndex = 0;
            this.lParentName.Text = "Parent Name";
            // 
            // lParentPhone
            // 
            this.lParentPhone.AutoSize = true;
            this.lParentPhone.Location = new System.Drawing.Point(17, 75);
            this.lParentPhone.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lParentPhone.Name = "lParentPhone";
            this.lParentPhone.Size = new System.Drawing.Size(188, 22);
            this.lParentPhone.TabIndex = 0;
            this.lParentPhone.Text = "Parent Phone Number";
            // 
            // tParentEmail
            // 
            this.tParentEmail.Location = new System.Drawing.Point(213, 111);
            this.tParentEmail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tParentEmail.Name = "tParentEmail";
            this.tParentEmail.Size = new System.Drawing.Size(289, 27);
            this.tParentEmail.TabIndex = 2;
            // 
            // lParentEmail
            // 
            this.lParentEmail.AutoSize = true;
            this.lParentEmail.Location = new System.Drawing.Point(17, 115);
            this.lParentEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lParentEmail.Name = "lParentEmail";
            this.lParentEmail.Size = new System.Drawing.Size(112, 22);
            this.lParentEmail.TabIndex = 0;
            this.lParentEmail.Text = "Parent Email";
            // 
            // gParentInfo
            // 
            this.gParentInfo.Controls.Add(this.tParentEmail);
            this.gParentInfo.Controls.Add(this.tParentPhone);
            this.gParentInfo.Controls.Add(this.tParentName);
            this.gParentInfo.Controls.Add(this.lParentEmail);
            this.gParentInfo.Controls.Add(this.lParentPhone);
            this.gParentInfo.Controls.Add(this.lParentName);
            this.gParentInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gParentInfo.Location = new System.Drawing.Point(485, 191);
            this.gParentInfo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gParentInfo.Name = "gParentInfo";
            this.gParentInfo.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gParentInfo.Size = new System.Drawing.Size(547, 154);
            this.gParentInfo.TabIndex = 7;
            this.gParentInfo.TabStop = false;
            this.gParentInfo.Text = "Parent Information";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tEMERel);
            this.groupBox1.Controls.Add(this.tEMEName);
            this.groupBox1.Controls.Add(this.tEMEPhone);
            this.groupBox1.Controls.Add(this.lEName);
            this.groupBox1.Controls.Add(this.lEPhone);
            this.groupBox1.Controls.Add(this.lERel);
            this.groupBox1.Location = new System.Drawing.Point(485, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(547, 163);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Emergency Contact";
            // 
            // tEMERel
            // 
            this.tEMERel.Location = new System.Drawing.Point(213, 122);
            this.tEMERel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tEMERel.Name = "tEMERel";
            this.tEMERel.Size = new System.Drawing.Size(289, 27);
            this.tEMERel.TabIndex = 2;
            // 
            // tEMEName
            // 
            this.tEMEName.Location = new System.Drawing.Point(213, 43);
            this.tEMEName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tEMEName.Name = "tEMEName";
            this.tEMEName.Size = new System.Drawing.Size(289, 27);
            this.tEMEName.TabIndex = 0;
            // 
            // tEMEPhone
            // 
            this.tEMEPhone.Location = new System.Drawing.Point(213, 82);
            this.tEMEPhone.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tEMEPhone.Name = "tEMEPhone";
            this.tEMEPhone.Size = new System.Drawing.Size(289, 27);
            this.tEMEPhone.TabIndex = 1;
            // 
            // lEName
            // 
            this.lEName.AutoSize = true;
            this.lEName.Location = new System.Drawing.Point(17, 43);
            this.lEName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lEName.Name = "lEName";
            this.lEName.Size = new System.Drawing.Size(146, 22);
            this.lEName.TabIndex = 0;
            this.lEName.Text = "Emegency Name";
            // 
            // lEPhone
            // 
            this.lEPhone.AutoSize = true;
            this.lEPhone.Location = new System.Drawing.Point(17, 86);
            this.lEPhone.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lEPhone.Name = "lEPhone";
            this.lEPhone.Size = new System.Drawing.Size(197, 22);
            this.lEPhone.TabIndex = 0;
            this.lEPhone.Text = "Contact Phone Number";
            // 
            // lERel
            // 
            this.lERel.AutoSize = true;
            this.lERel.Location = new System.Drawing.Point(17, 126);
            this.lERel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lERel.Name = "lERel";
            this.lERel.Size = new System.Drawing.Size(109, 22);
            this.lERel.TabIndex = 0;
            this.lERel.Text = "Relationship";
            // 
            // gBMain
            // 
            this.gBMain.Controls.Add(this.ckBUnderAge);
            this.gBMain.Controls.Add(this.lAddress);
            this.gBMain.Controls.Add(this.lMemEmail);
            this.gBMain.Controls.Add(this.cbMemDetail);
            this.gBMain.Controls.Add(this.bAddPic);
            this.gBMain.Controls.Add(this.lMemDe);
            this.gBMain.Controls.Add(this.tMemEmail);
            this.gBMain.Controls.Add(this.lPhoneNum);
            this.gBMain.Controls.Add(this.tAddress);
            this.gBMain.Controls.Add(this.lName);
            this.gBMain.Controls.Add(this.tPhoneNum);
            this.gBMain.Controls.Add(this.tName);
            this.gBMain.Location = new System.Drawing.Point(20, 23);
            this.gBMain.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gBMain.Name = "gBMain";
            this.gBMain.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gBMain.Size = new System.Drawing.Size(458, 322);
            this.gBMain.TabIndex = 10;
            this.gBMain.TabStop = false;
            // 
            // AddMemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MemIDFunc_namespace.Properties.Resources.Logo1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1047, 438);
            this.Controls.Add(this.gBMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gParentInfo);
            this.Controls.Add(this.bFinish);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "AddMemForm";
            this.Text = "Adding Member";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AtFormClosing);
            this.Load += new System.EventHandler(this.AddMemForm_Load);
            this.gParentInfo.ResumeLayout(false);
            this.gParentInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gBMain.ResumeLayout(false);
            this.gBMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lPhoneNum;
        private System.Windows.Forms.Label lMemDe;
        private System.Windows.Forms.Button bAddPic;
        private System.Windows.Forms.Label lAddress;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.TextBox tPhoneNum;
        private System.Windows.Forms.TextBox tAddress;
        private System.Windows.Forms.Button bFinish;
        private System.Windows.Forms.CheckBox ckBUnderAge;
        private System.Windows.Forms.ComboBox cbMemDetail;
        private System.Windows.Forms.Label lMemEmail;
        private System.Windows.Forms.TextBox tMemEmail;
        private System.Windows.Forms.TextBox tParentName;
        private System.Windows.Forms.TextBox tParentPhone;
        private System.Windows.Forms.Label lParentName;
        private System.Windows.Forms.Label lParentPhone;
        private System.Windows.Forms.TextBox tParentEmail;
        private System.Windows.Forms.Label lParentEmail;
        private System.Windows.Forms.GroupBox gParentInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tEMERel;
        private System.Windows.Forms.TextBox tEMEName;
        private System.Windows.Forms.TextBox tEMEPhone;
        private System.Windows.Forms.Label lEName;
        private System.Windows.Forms.Label lEPhone;
        private System.Windows.Forms.Label lERel;
        private System.Windows.Forms.GroupBox gBMain;
    }
}