namespace Agron
{
    partial class Login
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
            button7 = new Button();
            button5 = new Button();
            button2 = new Button();
            button1 = new Button();
            button4 = new Button();
            menuStrip1 = new MenuStrip();
            configuracionToolStripMenuItem = new ToolStripMenuItem();
            datosEmpresaToolStripMenuItem = new ToolStripMenuItem();
            centroDeCostosToolStripMenuItem = new ToolStripMenuItem();
            bancosToolStripMenuItem = new ToolStripMenuItem();
            cuentasContablesToolStripMenuItem = new ToolStripMenuItem();
            insumosToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button7
            // 
            button7.Location = new Point(112, 122);
            button7.Margin = new Padding(2, 2, 2, 2);
            button7.Name = "button7";
            button7.Size = new Size(102, 39);
            button7.TabIndex = 20;
            button7.Text = "COBROS";
            button7.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(6, 122);
            button5.Margin = new Padding(2, 2, 2, 2);
            button5.Name = "button5";
            button5.Size = new Size(102, 39);
            button5.TabIndex = 19;
            button5.Text = "PAGOS";
            button5.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(112, 71);
            button2.Margin = new Padding(2, 2, 2, 2);
            button2.Name = "button2";
            button2.Size = new Size(102, 39);
            button2.TabIndex = 17;
            button2.Text = "VENTAS ";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(6, 71);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(102, 39);
            button1.TabIndex = 16;
            button1.Text = "COMPRAS";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(66, 188);
            button4.Margin = new Padding(1, 1, 1, 1);
            button4.Name = "button4";
            button4.Size = new Size(76, 20);
            button4.TabIndex = 15;
            button4.Text = "Salir";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { configuracionToolStripMenuItem, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(239, 24);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            // 
            // configuracionToolStripMenuItem
            // 
            configuracionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { datosEmpresaToolStripMenuItem, centroDeCostosToolStripMenuItem, bancosToolStripMenuItem, cuentasContablesToolStripMenuItem, insumosToolStripMenuItem, productosToolStripMenuItem });
            configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            configuracionToolStripMenuItem.Size = new Size(95, 22);
            configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // datosEmpresaToolStripMenuItem
            // 
            datosEmpresaToolStripMenuItem.Name = "datosEmpresaToolStripMenuItem";
            datosEmpresaToolStripMenuItem.Size = new Size(173, 22);
            datosEmpresaToolStripMenuItem.Text = "Datos Empresa";
            // 
            // centroDeCostosToolStripMenuItem
            // 
            centroDeCostosToolStripMenuItem.Name = "centroDeCostosToolStripMenuItem";
            centroDeCostosToolStripMenuItem.Size = new Size(173, 22);
            centroDeCostosToolStripMenuItem.Text = "Centro de Costos";
            // 
            // bancosToolStripMenuItem
            // 
            bancosToolStripMenuItem.Name = "bancosToolStripMenuItem";
            bancosToolStripMenuItem.Size = new Size(173, 22);
            bancosToolStripMenuItem.Text = "Bancos";
            // 
            // cuentasContablesToolStripMenuItem
            // 
            cuentasContablesToolStripMenuItem.Name = "cuentasContablesToolStripMenuItem";
            cuentasContablesToolStripMenuItem.Size = new Size(173, 22);
            cuentasContablesToolStripMenuItem.Text = "Cuentas Contables";
            // 
            // insumosToolStripMenuItem
            // 
            insumosToolStripMenuItem.Name = "insumosToolStripMenuItem";
            insumosToolStripMenuItem.Size = new Size(173, 22);
            insumosToolStripMenuItem.Text = "Insumos";
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(173, 22);
            productosToolStripMenuItem.Text = "Productos";
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 22);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(239, 221);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(menuStrip1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Login";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button7;
        private Button button5;
        private Button button2;
        private Button button1;
        private Button button4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem configuracionToolStripMenuItem;
        private ToolStripMenuItem datosEmpresaToolStripMenuItem;
        private ToolStripMenuItem centroDeCostosToolStripMenuItem;
        private ToolStripMenuItem bancosToolStripMenuItem;
        private ToolStripMenuItem cuentasContablesToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem insumosToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
    }
}

