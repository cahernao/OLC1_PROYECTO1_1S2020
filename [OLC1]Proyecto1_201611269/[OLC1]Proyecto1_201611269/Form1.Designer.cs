namespace _OLC1_Proyecto1_201611269
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualTecnicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analisisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_Principal = new System.Windows.Forms.TextBox();
            this.txt_Consola = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AFD_btnSiguiente = new System.Windows.Forms.Button();
            this.AFD_btnAnterior = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.manualesToolStripMenuItem,
            this.analisisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1491, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 19);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // manualesToolStripMenuItem
            // 
            this.manualesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualUsuarioToolStripMenuItem,
            this.manualTecnicoToolStripMenuItem});
            this.manualesToolStripMenuItem.Name = "manualesToolStripMenuItem";
            this.manualesToolStripMenuItem.Size = new System.Drawing.Size(70, 19);
            this.manualesToolStripMenuItem.Text = "Manuales";
            // 
            // manualUsuarioToolStripMenuItem
            // 
            this.manualUsuarioToolStripMenuItem.Name = "manualUsuarioToolStripMenuItem";
            this.manualUsuarioToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.manualUsuarioToolStripMenuItem.Text = "Manual Usuario";
            this.manualUsuarioToolStripMenuItem.Click += new System.EventHandler(this.manualUsuarioToolStripMenuItem_Click);
            // 
            // manualTecnicoToolStripMenuItem
            // 
            this.manualTecnicoToolStripMenuItem.Name = "manualTecnicoToolStripMenuItem";
            this.manualTecnicoToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.manualTecnicoToolStripMenuItem.Text = "Manual Tecnico";
            this.manualTecnicoToolStripMenuItem.Click += new System.EventHandler(this.manualTecnicoToolStripMenuItem_Click);
            // 
            // analisisToolStripMenuItem
            // 
            this.analisisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analizarToolStripMenuItem,
            this.generarXMLToolStripMenuItem});
            this.analisisToolStripMenuItem.Name = "analisisToolStripMenuItem";
            this.analisisToolStripMenuItem.Size = new System.Drawing.Size(59, 19);
            this.analisisToolStripMenuItem.Text = "Analisis";
            this.analisisToolStripMenuItem.Click += new System.EventHandler(this.analisisToolStripMenuItem_Click);
            // 
            // analizarToolStripMenuItem
            // 
            this.analizarToolStripMenuItem.Name = "analizarToolStripMenuItem";
            this.analizarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.analizarToolStripMenuItem.Text = "Analizar";
            this.analizarToolStripMenuItem.Click += new System.EventHandler(this.analizarToolStripMenuItem_Click);
            // 
            // generarXMLToolStripMenuItem
            // 
            this.generarXMLToolStripMenuItem.Name = "generarXMLToolStripMenuItem";
            this.generarXMLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.generarXMLToolStripMenuItem.Text = "Generar XML";
            this.generarXMLToolStripMenuItem.Click += new System.EventHandler(this.generarXMLToolStripMenuItem_Click);
            // 
            // txt_Principal
            // 
            this.txt_Principal.Location = new System.Drawing.Point(13, 30);
            this.txt_Principal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Principal.Multiline = true;
            this.txt_Principal.Name = "txt_Principal";
            this.txt_Principal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Principal.Size = new System.Drawing.Size(635, 567);
            this.txt_Principal.TabIndex = 1;
            // 
            // txt_Consola
            // 
            this.txt_Consola.BackColor = System.Drawing.SystemColors.InfoText;
            this.txt_Consola.ForeColor = System.Drawing.SystemColors.Info;
            this.txt_Consola.Location = new System.Drawing.Point(13, 623);
            this.txt_Consola.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Consola.Multiline = true;
            this.txt_Consola.Name = "txt_Consola";
            this.txt_Consola.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Consola.Size = new System.Drawing.Size(635, 171);
            this.txt_Consola.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AFD_btnSiguiente);
            this.groupBox1.Controls.Add(this.AFD_btnAnterior);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(684, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(769, 473);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AFD";
            // 
            // AFD_btnSiguiente
            // 
            this.AFD_btnSiguiente.Location = new System.Drawing.Point(417, 422);
            this.AFD_btnSiguiente.Name = "AFD_btnSiguiente";
            this.AFD_btnSiguiente.Size = new System.Drawing.Size(75, 41);
            this.AFD_btnSiguiente.TabIndex = 2;
            this.AFD_btnSiguiente.Text = ">";
            this.AFD_btnSiguiente.UseVisualStyleBackColor = true;
            this.AFD_btnSiguiente.Click += new System.EventHandler(this.AFD_btnSiguiente_Click);
            // 
            // AFD_btnAnterior
            // 
            this.AFD_btnAnterior.Location = new System.Drawing.Point(336, 422);
            this.AFD_btnAnterior.Name = "AFD_btnAnterior";
            this.AFD_btnAnterior.Size = new System.Drawing.Size(75, 41);
            this.AFD_btnAnterior.TabIndex = 1;
            this.AFD_btnAnterior.Text = "<";
            this.AFD_btnAnterior.UseVisualStyleBackColor = true;
            this.AFD_btnAnterior.Click += new System.EventHandler(this.AFD_btnAnterior_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(722, 428);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "ime");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(693, 530);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 266);
            this.dataGridView1.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 808);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_Consola);
            this.Controls.Add(this.txt_Principal);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proyecto1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualTecnicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analisisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarXMLToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_Principal;
        private System.Windows.Forms.TextBox txt_Consola;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AFD_btnSiguiente;
        private System.Windows.Forms.Button AFD_btnAnterior;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
    }
}

