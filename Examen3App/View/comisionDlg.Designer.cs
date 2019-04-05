namespace Examen3App.View
{
    partial class comisionDlg
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.yrDTpick = new System.Windows.Forms.DateTimePicker();
            this.showBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainGV = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.showBtn);
            this.panel1.Controls.Add(this.yrDTpick);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año a mostrar";
            // 
            // yrDTpick
            // 
            this.yrDTpick.Location = new System.Drawing.Point(245, 38);
            this.yrDTpick.Name = "yrDTpick";
            this.yrDTpick.Size = new System.Drawing.Size(200, 20);
            this.yrDTpick.TabIndex = 1;
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(570, 25);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(115, 50);
            this.showBtn.TabIndex = 2;
            this.showBtn.Text = "Mostrar comisiones";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mainGV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 350);
            this.panel2.TabIndex = 1;
            // 
            // mainGV
            // 
            this.mainGV.AllowUserToAddRows = false;
            this.mainGV.AllowUserToDeleteRows = false;
            this.mainGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mainGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.mainGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGV.Location = new System.Drawing.Point(0, 0);
            this.mainGV.Name = "mainGV";
            this.mainGV.ReadOnly = true;
            this.mainGV.Size = new System.Drawing.Size(800, 350);
            this.mainGV.TabIndex = 0;
            // 
            // comisionDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "comisionDlg";
            this.Text = "comisionDlg";
            this.Load += new System.EventHandler(this.comisionDlg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker yrDTpick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView mainGV;
    }
}