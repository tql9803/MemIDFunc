﻿namespace MemIDFunc_namespace
{
    partial class MemInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemInfoForm));
            this.memIDBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.memberID_dbDataSet = new MemIDFunc_namespace.MemberID_dbDataSet();
            this.memIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.memIDTableAdapter = new MemIDFunc_namespace.MemberID_dbDataSetTableAdapters.MemIDTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lGreeting = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.memIDBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberID_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memIDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // memIDBindingSource1
            // 
            this.memIDBindingSource1.DataMember = "MemID";
            this.memIDBindingSource1.DataSource = this.memberID_dbDataSet;
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
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1017, 512);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lGreeting
            // 
            this.lGreeting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lGreeting.AutoSize = true;
            this.lGreeting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lGreeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGreeting.Location = new System.Drawing.Point(273, 531);
            this.lGreeting.Name = "lGreeting";
            this.lGreeting.Size = new System.Drawing.Size(135, 33);
            this.lGreeting.TabIndex = 2;
            this.lGreeting.Text = "lGreeting";
            this.lGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MemInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 574);
            this.Controls.Add(this.lGreeting);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MemInfoForm";
            this.Text = "MemInfoForm";
            this.Load += new System.EventHandler(this.MemInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memIDBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberID_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memIDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MemberID_dbDataSet memberID_dbDataSet;
        private System.Windows.Forms.BindingSource memIDBindingSource;
        private MemberID_dbDataSetTableAdapters.MemIDTableAdapter memIDTableAdapter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource memIDBindingSource1;
        private System.Windows.Forms.Label lGreeting;
    }
}