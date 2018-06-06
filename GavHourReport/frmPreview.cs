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
    public partial class frmPreview : Form
    {
        Image myImage;
        public frmPreview(Image previewImage)
        {
            myImage = previewImage;
            InitializeComponent();
        }

        private void frmPreview_Load(object sender, EventArgs e)
        {
            pbPreview.Image = myImage;
        }

        private void okContinueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
