﻿namespace MainUI_namespace.Forms
{
    partial class CheckInOutForm
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
            this.bScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bScan
            // 
            this.bScan.Location = new System.Drawing.Point(281, 252);
            this.bScan.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.bScan.Name = "bScan";
            this.bScan.Size = new System.Drawing.Size(138, 28);
            this.bScan.TabIndex = 0;
            this.bScan.Text = "Start";
            this.bScan.UseVisualStyleBackColor = true;
            this.bScan.Click += new System.EventHandler(this.bScan_Click);
            // 
            // CheckInOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 588);
            this.Controls.Add(this.bScan);
            this.Font = new System.Drawing.Font("Copperplate Gothic Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "CheckInOutForm";
            this.Text = "CheckInOutForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bScan;
    }
}