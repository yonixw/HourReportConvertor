namespace GavHourReport
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadEXELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXPORTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOther = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTemplateToolStripMenuItem,
            this.loadEXELToolStripMenuItem,
            this.eXPORTToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(972, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadTemplateToolStripMenuItem
            // 
            this.loadTemplateToolStripMenuItem.Name = "loadTemplateToolStripMenuItem";
            this.loadTemplateToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.loadTemplateToolStripMenuItem.Text = "1) Init days";
            this.loadTemplateToolStripMenuItem.Click += new System.EventHandler(this.loadTemplateToolStripMenuItem_Click);
            // 
            // loadEXELToolStripMenuItem
            // 
            this.loadEXELToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.loadEXELToolStripMenuItem.Name = "loadEXELToolStripMenuItem";
            this.loadEXELToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.loadEXELToolStripMenuItem.Text = "2) Load hours";
            // 
            // eXPORTToolStripMenuItem
            // 
            this.eXPORTToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.eXPORTToolStripMenuItem.Name = "eXPORTToolStripMenuItem";
            this.eXPORTToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.eXPORTToolStripMenuItem.Text = "3) EXPORT";
            this.eXPORTToolStripMenuItem.Click += new System.EventHandler(this.eXPORTToolStripMenuItem_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDate,
            this.cDay,
            this.cStart,
            this.cTIME,
            this.cOther});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 24);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(972, 529);
            this.dgvData.TabIndex = 2;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(301, 22);
            this.toolStripMenuItem2.Text = "נוכחות-דוח שעות מפורט לפי עובד";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.loadEXELToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(301, 22);
            this.toolStripMenuItem3.Text = "נוכחות-דוח ניתוח שעות והכנה לשכר לאקסל";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // cDate
            // 
            this.cDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDate.HeaderText = "Date";
            this.cDate.Name = "cDate";
            this.cDate.ReadOnly = true;
            this.cDate.Width = 55;
            // 
            // cDay
            // 
            this.cDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDay.HeaderText = "Day";
            this.cDay.Name = "cDay";
            this.cDay.ReadOnly = true;
            this.cDay.Width = 51;
            // 
            // cStart
            // 
            this.cStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cStart.HeaderText = "Start Work";
            this.cStart.Name = "cStart";
            this.cStart.Width = 83;
            // 
            // cTIME
            // 
            this.cTIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTIME.HeaderText = "Total Work";
            this.cTIME.Name = "cTIME";
            this.cTIME.Width = 85;
            // 
            // cOther
            // 
            this.cOther.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cOther.HeaderText = "Reason?";
            this.cOther.Items.AddRange(new object[] {
            "חשבון המערכת (התעלם)",
            "מחלה באישור",
            "חופשה",
            "מחלת ילד",
            "הולדת בן/בת"});
            this.cOther.Name = "cOther";
            this.cOther.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cOther.Width = 56;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 553);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Work hour converter v1.0 ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadEXELToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXPORTToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTIME;
        private System.Windows.Forms.DataGridViewComboBoxColumn cOther;
    }
}

