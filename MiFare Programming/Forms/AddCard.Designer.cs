namespace MainUI_namespace.Forms
{
    partial class AddCard
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
            this.bAddCard = new System.Windows.Forms.Button();
            this.bScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAddCard
            // 
            this.bAddCard.Location = new System.Drawing.Point(152, 289);
            this.bAddCard.Name = "bAddCard";
            this.bAddCard.Size = new System.Drawing.Size(99, 60);
            this.bAddCard.TabIndex = 1;
            this.bAddCard.Text = "Add Card";
            this.bAddCard.UseVisualStyleBackColor = true;
            this.bAddCard.Click += new System.EventHandler(this.bAddCard_Click);
            // 
            // bScan
            // 
            this.bScan.Location = new System.Drawing.Point(152, 110);
            this.bScan.Name = "bScan";
            this.bScan.Size = new System.Drawing.Size(99, 60);
            this.bScan.TabIndex = 1;
            this.bScan.Text = "Scan Card";
            this.bScan.UseVisualStyleBackColor = true;
            this.bScan.Click += new System.EventHandler(this.bScan_Click);
            // 
            // AddCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 476);
            this.Controls.Add(this.bScan);
            this.Controls.Add(this.bAddCard);
            this.Name = "AddCard";
            this.Text = "Add Card";
            this.Load += new System.EventHandler(this.AddCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAddCard;
        private System.Windows.Forms.Button bScan;
    }
}