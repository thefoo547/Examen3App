namespace Examen3App
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeÓrdenesDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comisionesDeEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operacionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeÓrdenesDeClientesToolStripMenuItem,
            this.comisionesDeEmpleadosToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // listaDeÓrdenesDeClientesToolStripMenuItem
            // 
            this.listaDeÓrdenesDeClientesToolStripMenuItem.Name = "listaDeÓrdenesDeClientesToolStripMenuItem";
            this.listaDeÓrdenesDeClientesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.listaDeÓrdenesDeClientesToolStripMenuItem.Text = "Lista de órdenes de clientes";
            // 
            // comisionesDeEmpleadosToolStripMenuItem
            // 
            this.comisionesDeEmpleadosToolStripMenuItem.Name = "comisionesDeEmpleadosToolStripMenuItem";
            this.comisionesDeEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.comisionesDeEmpleadosToolStripMenuItem.Text = "Comisiones a empleados";
            this.comisionesDeEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.comisionesDeEmpleadosToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Northwind";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeÓrdenesDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comisionesDeEmpleadosToolStripMenuItem;
    }
}

