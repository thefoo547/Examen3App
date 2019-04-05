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
    public partial class listaclientesDlg : Form
    {
        public listaclientesDlg()
        {
            InitializeComponent();
        }

        private void msgerr(String msg)
        {
            MessageBox.Show(this, msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listaclientesDlg_Load(object sender, EventArgs e)
        {
            try
            {
                mainGV.DataSource = new CListaclientes().listaClientes();
                mainGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            } catch (Exception ex)
            {
                msgerr(ex.Message);
            }
        }
    }
}
