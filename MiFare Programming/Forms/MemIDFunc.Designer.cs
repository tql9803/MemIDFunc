namespace MainUI_namespace
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
            this.bReset = new System.Windows.Forms.Button();
            this.bQuit = new System.Windows.Forms.Button();
            this.memberID_dbDataSet = new MemIDFunc_namespace.MemberID_dbDataSet();
            this.memIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.memIDTableAdapter = new MemIDFunc_namespace.MemberID_dbDataSetTableAdapters.MemIDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.memberID_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memIDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bReset
            // 
            this.bReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bReset.BackColor = System.Drawing.Color.OrangeRed;
            this.bReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bReset.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReset.ForeColor = System.Drawing.Color.Blue;
            this.bReset.Location = new System.Drawing.Point(275, 422);
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
            this.bQuit.BackColor = System.Drawing.Color.OrangeRed;
            this.bQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bQuit.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bQuit.ForeColor = System.Drawing.Color.Blue;
            this.bQuit.Location = new System.Drawing.Point(119, 422);
            this.bQuit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bQuit.Name = "bQuit";
            this.bQuit.Size = new System.Drawing.Size(150, 50);
            this.bQuit.TabIndex = 10;
            this.bQuit.Text = "Quit";
            this.bQuit.UseVisualStyleBackColor = false;
            this.bQuit.Click += new System.EventHandler(this.bQuit_Click);
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
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImage = global::MemIDFunc_namespace.Properties.Resources.Logo11;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(556, 483);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.bQuit);
            this.Font = new System.Drawing.Font("Malgun Gothic Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.IndianRed;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barriere Gym and Fitness Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MiFareCardProg_Load);
            this.SizeChanged += new System.EventHandler(this.UI_OnSizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.memberID_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memIDBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button bReset;
        internal System.Windows.Forms.Button bQuit;
        private MemIDFunc_namespace.MemberID_dbDataSet memberID_dbDataSet;
        private System.Windows.Forms.BindingSource memIDBindingSource;
        private MemIDFunc_namespace.MemberID_dbDataSetTableAdapters.MemIDTableAdapter memIDTableAdapter;
    }
}

