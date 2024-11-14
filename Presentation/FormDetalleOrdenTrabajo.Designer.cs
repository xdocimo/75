namespace Presentation
{
    partial class FormDetalleOrdenTrabajo
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
            components = new System.ComponentModel.Container();
            button6 = new Button();
            button5 = new Button();
            cb1 = new ComboBox();
            detalleOrdenTrabajoBindingSource = new BindingSource(components);
            tv2 = new TextBox();
            label4 = new Label();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            dt1 = new DataGridView();
            tv1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            cb2 = new ComboBox();
            label1 = new Label();
            detalleOrdenTrabajoBindingSource1 = new BindingSource(components);
            label5 = new Label();
            id = new DataGridViewTextBoxColumn();
            ordenDeTrabajo = new DataGridViewTextBoxColumn();
            Insumo = new DataGridViewTextBoxColumn();
            cantidad = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenTrabajoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dt1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenTrabajoBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // button6
            // 
            button6.Location = new Point(176, 269);
            button6.Margin = new Padding(2);
            button6.Name = "button6";
            button6.Size = new Size(130, 42);
            button6.TabIndex = 41;
            button6.Text = "Consultar TODOS";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(22, 269);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(130, 42);
            button5.TabIndex = 40;
            button5.Text = "Consultar ID";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // cb1
            // 
            cb1.DropDownStyle = ComboBoxStyle.DropDownList;
            cb1.FormattingEnabled = true;
            cb1.Location = new Point(126, 74);
            cb1.Margin = new Padding(2);
            cb1.Name = "cb1";
            cb1.Size = new Size(211, 23);
            cb1.TabIndex = 39;
            cb1.SelectedIndexChanged += cb1_SelectedIndexChanged;
            // 
            // detalleOrdenTrabajoBindingSource
            // 
            detalleOrdenTrabajoBindingSource.DataSource = typeof(Modelos.DetalleOrdenTrabajo);
            // 
            // tv2
            // 
            tv2.Location = new Point(90, 154);
            tv2.Margin = new Padding(2);
            tv2.Name = "tv2";
            tv2.Size = new Size(160, 23);
            tv2.TabIndex = 38;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 157);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 37;
            label4.Text = "Cantidad:";
            // 
            // button4
            // 
            button4.Location = new Point(126, 210);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(87, 38);
            button4.TabIndex = 36;
            button4.Text = "Borrar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(226, 210);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(99, 38);
            button3.TabIndex = 35;
            button3.Text = "Modificar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(16, 328);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(56, 24);
            button2.TabIndex = 34;
            button2.Text = "Volver";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(22, 210);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(90, 38);
            button1.TabIndex = 33;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dt1
            // 
            dt1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dt1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dt1.Columns.AddRange(new DataGridViewColumn[] { id, ordenDeTrabajo, Insumo, cantidad });
            dt1.Location = new Point(367, 11);
            dt1.Margin = new Padding(2);
            dt1.Name = "dt1";
            dt1.RowHeadersWidth = 62;
            dt1.RowTemplate.Height = 33;
            dt1.Size = new Size(707, 328);
            dt1.TabIndex = 32;
            dt1.CellContentClick += dt1_CellContentClick;
            // 
            // tv1
            // 
            tv1.Location = new Point(64, 34);
            tv1.Margin = new Padding(2);
            tv1.Name = "tv1";
            tv1.Size = new Size(178, 23);
            tv1.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 37);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 30;
            label3.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 116);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 29;
            label2.Text = "Insumo:";
            // 
            // cb2
            // 
            cb2.DropDownStyle = ComboBoxStyle.DropDownList;
            cb2.FormattingEnabled = true;
            cb2.Location = new Point(90, 113);
            cb2.Margin = new Padding(2);
            cb2.Name = "cb2";
            cb2.Size = new Size(216, 23);
            cb2.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 77);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 27;
            label1.Text = "Orden de Trabajo:";
            // 
            // detalleOrdenTrabajoBindingSource1
            // 
            detalleOrdenTrabajoBindingSource1.DataSource = typeof(Modelos.DetalleOrdenTrabajo);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 9);
            label5.Name = "label5";
            label5.Size = new Size(169, 15);
            label5.TabIndex = 42;
            label5.Text = "Registrar Detalle Orden Trabajo";
            // 
            // id
            // 
            id.FillWeight = 15.87308F;
            id.HeaderText = "ID";
            id.Name = "id";
            // 
            // ordenDeTrabajo
            // 
            ordenDeTrabajo.FillWeight = 50.0423F;
            ordenDeTrabajo.HeaderText = "Orden de Trabajo";
            ordenDeTrabajo.Name = "ordenDeTrabajo";
            // 
            // Insumo
            // 
            Insumo.FillWeight = 25.0423012F;
            Insumo.HeaderText = "Insumo";
            Insumo.Name = "Insumo";
            // 
            // cantidad
            // 
            cantidad.FillWeight = 15.0423012F;
            cantidad.HeaderText = "Cantidad";
            cantidad.Name = "cantidad";
            // 
            // FormDetalleOrdenTrabajo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 363);
            Controls.Add(label5);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(cb1);
            Controls.Add(tv2);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dt1);
            Controls.Add(tv1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cb2);
            Controls.Add(label1);
            Name = "FormDetalleOrdenTrabajo";
            Text = "Form1";
            Load += FormDetalleOrdenTrabajo_Load;
            ((System.ComponentModel.ISupportInitialize)detalleOrdenTrabajoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dt1).EndInit();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenTrabajoBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button6;
        private Button button5;
        private ComboBox cb1;
        private TextBox tv2;
        private Label label4;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private DataGridView dt1;
        private TextBox tv1;
        private Label label3;
        private Label label2;
        private ComboBox cb2;
        private Label label1;
        private BindingSource detalleOrdenTrabajoBindingSource;
        private BindingSource detalleOrdenTrabajoBindingSource1;
        private Label label5;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn ordenDeTrabajo;
        private DataGridViewTextBoxColumn Insumo;
        private DataGridViewTextBoxColumn cantidad;
    }
}