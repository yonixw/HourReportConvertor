using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GavHourReport
{
    public partial class frmDlgPassword : Form
    {
        public frmDlgPassword()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.ToLower() == "king"
                || txtPassword.Text == "מלך")
                DialogResult = DialogResult.OK;
        }
    }
}
