namespace GavHourReport
{
    partial class DayReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDate = new System.Windows.Forms.Label();
            this.rbWork = new System.Windows.Forms.RadioButton();
            this.lblBreak = new System.Windows.Forms.Label();
            this.rbVacation = new System.Windows.Forms.RadioButton();
            this.rbSick = new System.Windows.Forms.RadioButton();
            this.rbDisable = new System.Windows.Forms.RadioButton();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDate.Location = new System.Drawing.Point(9, 8);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(93, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "25/33 Tuesday";
            // 
            // rbWork
            // 
            this.rbWork.AutoSize = true;
            this.rbWork.Checked = true;
            this.rbWork.Location = new System.Drawing.Point(106, 6);
            this.rbWork.Name = "rbWork";
            this.rbWork.Size = new System.Drawing.Size(65, 17);
            this.rbWork.TabIndex = 1;
            this.rbWork.TabStop = true;
            this.rbWork.Text = "All Work";
            this.rbWork.UseVisualStyleBackColor = true;
            this.rbWork.CheckedChanged += new System.EventHandler(this.rbWork_CheckedChanged);
            // 
            // lblBreak
            // 
            this.lblBreak.AutoSize = true;
            this.lblBreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblBreak.Location = new System.Drawing.Point(215, 8);
            this.lblBreak.Name = "lblBreak";
            this.lblBreak.Size = new System.Drawing.Size(49, 13);
            this.lblBreak.TabIndex = 3;
            this.lblBreak.Text = "BREAK?";
            // 
            // rbVacation
            // 
            this.rbVacation.AutoSize = true;
            this.rbVacation.Location = new System.Drawing.Point(269, 5);
            this.rbVacation.Name = "rbVacation";
            this.rbVacation.Size = new System.Drawing.Size(67, 17);
            this.rbVacation.TabIndex = 4;
            this.rbVacation.Text = "Vacation";
            this.rbVacation.UseVisualStyleBackColor = true;
            this.rbVacation.CheckedChanged += new System.EventHandler(this.rbVacation_CheckedChanged);
            // 
            // rbSick
            // 
            this.rbSick.AutoSize = true;
            this.rbSick.Location = new System.Drawing.Point(342, 5);
            this.rbSick.Name = "rbSick";
            this.rbSick.Size = new System.Drawing.Size(46, 17);
            this.rbSick.TabIndex = 5;
            this.rbSick.Text = "Sick";
            this.rbSick.UseVisualStyleBackColor = true;
            this.rbSick.CheckedChanged += new System.EventHandler(this.rbSick_CheckedChanged);
            // 
            // rbDisable
            // 
            this.rbDisable.AutoSize = true;
            this.rbDisable.Enabled = false;
            this.rbDisable.Location = new System.Drawing.Point(396, 5);
            this.rbDisable.Name = "rbDisable";
            this.rbDisable.Size = new System.Drawing.Size(87, 17);
            this.rbDisable.TabIndex = 6;
            this.rbDisable.Text = "(Not needed)";
            this.rbDisable.UseVisualStyleBackColor = true;
            // 
            // txtHour
            // 
            this.txtHour.Location = new System.Drawing.Point(169, 4);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(44, 20);
            this.txtHour.TabIndex = 7;
            this.txtHour.Text = "0";
            this.txtHour.TextChanged += new System.EventHandler(this.txtHour_TextChanged);
            this.txtHour.Validating += new System.ComponentModel.CancelEventHandler(this.txtHour_Validating);
            // 
            // DayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.Controls.Add(this.txtHour);
            this.Controls.Add(this.rbDisable);
            this.Controls.Add(this.rbSick);
            this.Controls.Add(this.rbVacation);
            this.Controls.Add(this.lblBreak);
            this.Controls.Add(this.rbWork);
            this.Controls.Add(this.lblDate);
            this.Name = "DayReport";
            this.Size = new System.Drawing.Size(503, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.RadioButton rbWork;
        private System.Windows.Forms.Label lblBreak;
        private System.Windows.Forms.RadioButton rbVacation;
        private System.Windows.Forms.RadioButton rbSick;
        private System.Windows.Forms.RadioButton rbDisable;
        private System.Windows.Forms.TextBox txtHour;
    }
}
