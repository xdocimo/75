﻿using Agron;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormCobros : Form
    {
        public FormCobros()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCliente formCliente = new FormCliente();
            formCliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCuenta formCuenta = new FormCuenta();
            formCuenta.Show();
        }
    }
}
