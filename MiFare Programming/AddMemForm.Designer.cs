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
            this.lName = new System.Windows.Forms.Label();
            this.lPhoneNum = new System.Windows.Forms.Label();
            this.lMemDe = new System.Windows.Forms.Label();
            this.bAddPic = new System.Windows.Forms.Button();
            this.lAddress = new System.Windows.Forms.Label();
            this.tName = new System.Windows.Forms.TextBox();
            this.tPhoneNum = new System.Windows.Forms.TextBox();
            this.tAddress = new System.Windows.Forms.TextBox();
            this.tMemDetail = new System.Windows.Forms.TextBox();
            this.bFinish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(12, 32);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 0;
            this.lName.Text = "Name";
            // 
            // lPhoneNum
            // 
            this.lPhoneNum.AutoSize = true;
            this.lPhoneNum.Location = new System.Drawing.Point(12, 56);
            this.lPhoneNum.Name = "lPhoneNum";
            this.lPhoneNum.Size = new System.Drawing.Size(78, 13);
            this.lPhoneNum.TabIndex = 0;
            this.lPhoneNum.Text = "Phone Number";
            // 
            // lMemDe
            // 
            this.lMemDe.AutoSize = true;
            this.lMemDe.Location = new System.Drawing.Point(12, 108);
            this.lMemDe.Name = "lMemDe";
            this.lMemDe.Size = new System.Drawing.Size(94, 13);
            this.lMemDe.TabIndex = 0;
            this.lMemDe.Text = "Membership Detail";
            // 
            // bAddPic
            // 
            this.bAddPic.Location = new System.Drawing.Point(12, 157);
            this.bAddPic.Name = "bAddPic";
            this.bAddPic.Size = new System.Drawing.Size(75, 23);
            this.bAddPic.TabIndex = 4;
            this.bAddPic.Text = "Add Picture";
            this.bAddPic.UseVisualStyleBackColor = true;
            // 
            // lAddress
            // 
            this.lAddress.AutoSize = true;
            this.lAddress.Location = new System.Drawing.Point(12, 82);
            this.lAddress.Name = "lAddress";
            this.lAddress.Size = new System.Drawing.Size(45, 13);
            this.lAddress.TabIndex = 0;
            this.lAddress.Text = "Address";
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(110, 25);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(174, 20);
            this.tName.TabIndex = 0;
            // 
            // tPhoneNum
            // 
            this.tPhoneNum.Location = new System.Drawing.Point(110, 49);
            this.tPhoneNum.Name = "tPhoneNum";
            this.tPhoneNum.Size = new System.Drawing.Size(174, 20);
            this.tPhoneNum.TabIndex = 1;
            // 
            // tAddress
            // 
            this.tAddress.Location = new System.Drawing.Point(110, 75);
            this.tAddress.Name = "tAddress";
            this.tAddress.Size = new System.Drawing.Size(174, 20);
            this.tAddress.TabIndex = 2;
            // 
            // tMemDetail
            // 
            this.tMemDetail.Location = new System.Drawing.Point(110, 101);
            this.tMemDetail.Name = "tMemDetail";
            this.tMemDetail.Size = new System.Drawing.Size(174, 20);
            this.tMemDetail.TabIndex = 3;
            // 
            // bFinish
            // 
            this.bFinish.Location = new System.Drawing.Point(209, 157);
            this.bFinish.Name = "bFinish";
            this.bFinish.Size = new System.Drawing.Size(75, 23);
            this.bFinish.TabIndex = 5;
            this.bFinish.Text = "Finish";
            this.bFinish.UseVisualStyleBackColor = true;
            this.bFinish.Click += new System.EventHandler(this.bFinish_Click);
            // 
            // AddMemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 192);
            this.Controls.Add(this.tMemDetail);
            this.Controls.Add(this.tAddress);
            this.Controls.Add(this.tPhoneNum);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.bFinish);
            this.Controls.Add(this.bAddPic);
            this.Controls.Add(this.lAddress);
            this.Controls.Add(this.lMemDe);
            this.Controls.Add(this.lPhoneNum);
            this.Controls.Add(this.lName);
            this.Name = "AddMemForm";
            this.Text = "Adding Member";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AtFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox tMemDetail;
        private System.Windows.Forms.Button bFinish;
    }
}