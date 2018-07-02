using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace GavHourReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CultureInfo culture = new System.Globalization.CultureInfo("he-IL");
        public static string dateFormat = "dd/MM/yyyy";

        DateTime lastMonthLoad = DateTime.MinValue;
        private void loadTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //string inputDate = Microsoft.VisualBasic.Interaction.InputBox("Put Date: <MM>/<YY>");
                frmDateChooser frmDateChooser = new frmDateChooser();
                if (frmDateChooser.ShowDialog() == DialogResult.OK)
                {
                    DateTime day = frmDateChooser.ResultDate;
                    int currentMonth = -1;

                    dgvData.Rows.Clear();
                    lastMonthLoad = day;

                    currentMonth = day.Month;

                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = Color.Salmon;

                    DataGridViewCellStyle styleDefault = new DataGridViewCellStyle();
                    styleDefault.BackColor = Color.White;


                    while (day.Month == currentMonth)
                    {
                        dgvData.Rows.Add(new object[] {
                                day.ToString(dateFormat),
                                culture.DateTimeFormat.GetDayName(day.DayOfWeek),
                                "00:00","00:00"});

                        if (day.DayOfWeek == DayOfWeek.Friday || day.DayOfWeek == DayOfWeek.Saturday)
                        {
                            dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle = style;
                            DataGridViewComboBoxCell cell =
                            ((DataGridViewComboBoxCell)dgvData.Rows[dgvData.Rows.Count - 1].Cells["cOther"]);
                            cell.Value = cell.Items[0];
                        }
                        else
                        {
                            dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle = styleDefault;
                        }

                        day = day.AddDays(1);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void colorizeTable()
        {
            DataGridViewCellStyle styleHighlight = new DataGridViewCellStyle();
            styleHighlight.BackColor = Color.Yellow;

            DataGridViewCellStyle styleDefault = new DataGridViewCellStyle();
            styleDefault.BackColor = Color.White;

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.White) // Not weekend
                {
                    if ((string)row.Cells["cTIME"].Value == "00:00")
                        row.DefaultCellStyle = styleHighlight;
                    else
                        row.DefaultCellStyle = styleDefault;
                }
            }
        }

        private void loadEXELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((new frmPreview(GavHourReport.Properties.Resources.detailed).ShowDialog()) != DialogResult.OK)
                return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Choose RPT excel to import";
            dlg.Filter = "Excel|*.xls;*.xlsx";
            dlg.CheckFileExists = true;
            dlg.Multiselect = false;

            try
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Dictionary<string, ExcelFlow.DayInfo> importData = ExcelFlow.RPTImport.import(dlg.FileName);

                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        string dateKey = row.Cells[0].Value.ToString();
                        if (importData.ContainsKey(dateKey))
                        {
                            TimeSpan startTime = importData[dateKey].dayStart;
                            TimeSpan totalTime = importData[dateKey].dayLength;
                            row.Cells["cTIME"].Value = string.Format("{0:00}:{1:00}",
                               (int)totalTime.TotalHours,
                                    totalTime.Minutes);
                            row.Cells["cStart"].Value = string.Format("{0:00}:{1:00}",
                               (int)startTime.TotalHours,
                                    startTime.Minutes);
                        }
                    }

                    colorizeTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }



        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if ((new frmPreview(GavHourReport.Properties.Resources.prepare).ShowDialog()) != DialogResult.OK)
                return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Choose RPT excel to import";
            dlg.Filter = "Excel|*.xls;*.xlsx";
            dlg.CheckFileExists = true;
            dlg.Multiselect = false;

            try
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ExcelFlow.RPTImportType2.ImportResult importData = ExcelFlow.RPTImportType2.import(dlg.FileName);

                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        string dateKey = row.Cells[0].Value.ToString();
                        if (importData.days.ContainsKey(dateKey))
                        {
                            TimeSpan startTime = importData.days[dateKey].dayStart;
                            TimeSpan totalTime = importData.days[dateKey].dayLength;
                            row.Cells["cTIME"].Value = string.Format("{0:00}:{1:00}",
                               (int)totalTime.TotalHours,
                                    totalTime.Minutes);
                            row.Cells["cStart"].Value = string.Format("{0:00}:{1:00}",
                               (int)startTime.TotalHours,
                                    startTime.Minutes);
                        }
                    }

                    lblImportTotalHours.Text = exTimeStr(TimeSpan.FromHours(importData.reportedHours));

                    colorizeTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }


        private void eXPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((new frmPreview(GavHourReport.Properties.Resources.ticktack).ShowDialog()) != DialogResult.OK)
                return;

            try
            {
                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Title = "Choose GAV excel TEMPLATE";
                dlgOpen.Filter = "TICKTACK_TEMPLATEv1.3.xls|TICKTACK_TEMPLATEv1.3.xls";
                dlgOpen.CheckFileExists = true;
                dlgOpen.Multiselect = false;

                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.Title = "Save GAV EXPORT";
                dlgSave.Filter = "Excel|*.xls";
                dlgSave.CheckFileExists = false;

                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    if (dlgSave.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = dlgSave.FileName;
                        if (!savePath.EndsWith(".xls"))
                            savePath += ".xls";
                        ExcelFlow.GavExporter.export(lastMonthLoad, dgvData.Rows, dlgOpen.FileName, savePath);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string pass = Microsoft.VisualBasic.Interaction.InputBox("Yoni is _ _ _ _ ");
            if (pass.ToLower() != "king")
            {
                MessageBox.Show("Gal is not king. Bye bye.");
                Application.Exit();
            }

        }

        private void gAVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimeSpan minWorkForBreak = new TimeSpan(6, 0, 0);
            TimeSpan breakLength = new TimeSpan(0, 30, 0);

            TimeSpan totalEffectiveWork = TimeSpan.Zero;
            TimeSpan totalWorkHours = TimeSpan.Zero;
            TimeSpan totalBreak = TimeSpan.Zero;

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                try
                {

                    TimeSpan rowWorkLength = TimeSpan.Parse((string)row.Cells["cTIME"].Value);

                    if (rowWorkLength.TotalMinutes > 0)
                    {
                        if (rowWorkLength <= minWorkForBreak)
                        {
                            totalEffectiveWork += rowWorkLength;
                        }
                        else
                        {
                            totalBreak += breakLength;
                            totalEffectiveWork += rowWorkLength - breakLength;
                        }
                        totalWorkHours += rowWorkLength;
                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error on date:" + row.Cells[0].Value.ToString() + Environment.NewLine +
                      ex.Message + Environment.NewLine + ex.StackTrace
                      );
                }
            }

            MessageBox.Show(
                "Total work:\t" + exTimeStr(totalWorkHours) +
                "\nEffective work:\t" + exTimeStr(totalEffectiveWork) +
                "\nTotalBreak:\t" + exTimeStr(totalBreak)
                , "Stats (Gav)");
        }

        public static string exTimeStr(TimeSpan time)
        {
            return
                string.Format("{0:00} Hours, {1:00} min  or {2:00}.{3:00}",
                               (int)time.TotalHours,
                                    time.Minutes,
                                    (int)time.TotalHours,
                                    Math.Round(time.Minutes * 1.0 / 60, 2) * 100
                                    );
        }

        void updateCurrentTotal()
        {
            TimeSpan totalWorkHours = TimeSpan.Zero;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                try
                {

                    TimeSpan rowWorkLength = TimeSpan.Parse((string)row.Cells["cTIME"].Value);

                    if (rowWorkLength.TotalMinutes > 0)
                    {

                        totalWorkHours += rowWorkLength;
                    }

                }
                catch (Exception ex) { }
            }
            lblCurrentTotal.Text = exTimeStr(totalWorkHours);
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateCurrentTotal();
        }

        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateCurrentTotal();
        }
    }
}
