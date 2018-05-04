using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GavHourReport
{
    public partial class DayReport : UserControl
    {
        public DayReport()
        {
            InitializeComponent();
        }

        public float BreakMin { get; set; } // like 6 hour before taking break. (0.5 to take any time)

        public string DateString
        {
            get
            {
                return lblDate.Text;
            }
            set
            {
                lblDate.Text = value;
            }
        }

        public bool _enabled = false;
        public bool UserEnabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                this.Enabled = value;
                _enabled = value;

                if (value)
                {
                    this.BackColor = Color.LightGreen;
                    TimeWork = 0;
                }
                else
                {
                    this.BackColor = Color.Plum;
                    rbDisable.Checked = true;
                }
            }
        }

        float timeWork = 0; bool timeVacation = false, timeSick = false;

        public void Reset()
        {
            antiInfLoop = true;

            txtHour.Text = "0";
            rbWork.Checked = false;
            rbSick.Checked = false;
            rbVacation.Checked = false;

            antiInfLoop = false;

            timeWork = 0;
            timeVacation = false;
            timeSick = false;
        }


        public float TimeWork
        {
            get
            {
                if (timeWork > 0 )
                    return timeWork;
                return -1; // Dont use!
            }

            set
            {
                if (!UserEnabled)
                    throw new Exception("This day is not enabled!");

                Reset();
                timeWork = value;

                antiInfLoop = true;
                rbWork.Checked = true;
                txtHour.Text = value.ToString();
                antiInfLoop = true;

                FontStyle newStyle = FontStyle.Italic;
                if (value > 0 && value > BreakMin)
                {
                    newStyle |= FontStyle.Strikeout;
                }
                lblBreak.Font = new Font(lblBreak.Font, newStyle);
            }
        }

        public bool IsVacation
        {
            get
            {
                return timeVacation;
            }

            set
            {
                if (!UserEnabled)
                    throw new Exception("This day is not enabled!");

                Reset();
                timeVacation = value;

                antiInfLoop = true;
                rbVacation.Checked = true;
                antiInfLoop = false;
            }
        }

        public bool IsSick
        {
            get
            {
                return timeSick;
            }

            set
            {
                if (!UserEnabled)
                    throw new Exception("This day is not enabled!");

                Reset();
                timeSick = value;

                antiInfLoop = true;
                rbSick.Checked = true;
                antiInfLoop = false;
            }
        }

        bool antiInfLoop = false;
        private void txtHour_TextChanged(object sender, EventArgs e)
        {
            if (!antiInfLoop)
                try
                {
                    TimeWork = float.Parse(txtHour.Text);

                }
                catch (Exception ex){ }
        }

        private void rbWork_CheckedChanged(object sender, EventArgs e)
        {
            if (!antiInfLoop)
                try
                {
                    TimeWork = float.Parse(txtHour.Text);

                }
                catch (Exception ex) { }
        }

        private void rbVacation_CheckedChanged(object sender, EventArgs e)
        {

            if (!antiInfLoop)
                IsVacation = true;
            
        }

        private void rbSick_CheckedChanged(object sender, EventArgs e)
        {

            if (!antiInfLoop)
                IsSick = true;
  
        }

        private void txtHour_Validating(object sender, CancelEventArgs e)
        {
            
            e.Cancel = false;
        }
    }
}
