using Examen3App.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen3App.View
{
    public partial class comisionDlg : Form
    {
        public comisionDlg()
        {
            InitializeComponent();
        }

        private void msgerr(String msg)
        {
            MessageBox.Show(this, msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            int yr = yrDTpick.Value.Year;
            try
            {
                mainGV.DataSource = new CComisiones().Comisiones(yr);
                mainGV.Columns[0].Visible = false;
                mainGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch(Exception ex)
            {
                msgerr(ex.Message);
            }
        }

        private void comisionDlg_Load(object sender, EventArgs e)
        {
            yrDTpick.Format = DateTimePickerFormat.Custom;
            yrDTpick.CustomFormat = "yyyy";
        }
    }
}
