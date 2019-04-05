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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comisionesDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comisionDlg dlg = new comisionDlg();
            dlg.ShowDialog();
        }

        private void listaDeÓrdenesDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaclientesDlg dlg = new listaclientesDlg();
            dlg.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            login log = new login();
            if (log.ShowDialog() == DialogResult.Cancel)
            {
                this.Close();
            }
        }
    }
}
