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
    public partial class frmDateChooser : Form
    {
        public frmDateChooser()
        {
            InitializeComponent();
        }

        public DateTime ResultDate = DateTime.Now;

        private void btnOk_Click(object sender, EventArgs e)
        {
            ResultDate = pickDate.Value;
            DialogResult = DialogResult.OK;
        }

        private void frmDateChooser_Load(object sender, EventArgs e)
        {
            pickDate.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
