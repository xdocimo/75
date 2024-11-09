using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FormDetalleOrdenTrabajo : Form
    {

        public FormDetalleOrdenTrabajo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (CamposCompletos())
            {
                try
                {
                    int ordenDeTrabajo = Convert.ToInt32(cb1.Text);
                    int insumo = Convert.ToInt32(cb2.Text);
                    decimal cantidad = Convert.ToDecimal(tv2.Text);

                    DDetalleOrdenTrabajo.InsertDetalleOrdenTrabajo(ordenDeTrabajo, insumo, cantidad);
                    MessageBox.Show("Detalle de orden de trabajo insertado con éxito.");
                    VaciarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Grave: " + ex.Message);
                }
                button6_Click(sender, e); // Es para refrescar los campos (llama al GetAll)
            }

            else
            {
                MessageBox.Show("Faltan completar campos");
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {

            {
                try
                {
                    var detalles = DDetalleOrdenTrabajo.GetAll();

                    dt1.Rows.Clear();


                    foreach (var detalle in detalles)
                    {
                        dt1.Rows.Add(detalle.id, detalle.ordenDeTrabajo, detalle.insumo, detalle.cantidad);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tv1.Text)) { 
            try
            {

                int id = Convert.ToInt32(tv1.Text);


                var detalle = DDetalleOrdenTrabajo.GetById(id);


                dt1.Rows.Clear();


                if (detalle != null && detalle.id != 0) // Agregada la condicional esto por el BUG de los ceros
                {

                    dt1.Rows.Add(detalle.id, detalle.ordenDeTrabajo, detalle.insumo, detalle.cantidad);

                }
                else
                {

                    MessageBox.Show("No existe ese ID");
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error grave");
                // Console.WriteLine(ex.ToString()); // Debugeando
            }

            }
            else
            {
                MessageBox.Show("Introduzca una ID");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CamposCompletos())
            {


            {
                try
                {
                    int id = Convert.ToInt32(tv1.Text); // _--> Esta ID modificamos:
                    int ordenDeTrabajo = Convert.ToInt32(cb1.Text);
                    int insumo = Convert.ToInt32(cb2.Text);
                    decimal cantidad = Convert.ToDecimal(tv2.Text);


                    DDetalleOrdenTrabajo.UpdateDetalleOrdenTrabajo(id, ordenDeTrabajo, insumo, cantidad);


                    MessageBox.Show("Actualizado con exito");


                    button6_Click(sender, e); // Es para refrescar los campos (llama al GetAll)
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR");
                }
            }
            }
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool CamposCompletos()
        {
            return !string.IsNullOrEmpty(cb1.Text) &&
                   !string.IsNullOrEmpty(cb2.Text) &&
                   !string.IsNullOrEmpty(tv2.Text);
        }


        private void FormDetalleOrdenTrabajo_Load(object sender, EventArgs e)
        {
            LoaderComboInsumo();
            LoaderComboOrdenTrabajo();
            button6_Click(sender, e); // Cargar la tabla por Default
        }



        private void VaciarCampos()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1; 
                }
                else if (control is DataGridView)
                {
                    ((DataGridView)control).Rows.Clear();
                }
            }
        }


        public void LoaderComboInsumo()
        {
            var insumoIds = DDetalleOrdenTrabajo.GetAllInsumoIds();
            cb2.Items.Clear(); 
            foreach (var id in insumoIds)
            {
                cb2.Items.Add(id);
            }
        }

        public void LoaderComboOrdenTrabajo()
        {
            var ordenIds = DDetalleOrdenTrabajo.GetAllOrdenTrabajoIds();
            cb1.Items.Clear();
            foreach (var id in ordenIds)
            {
                cb1.Items.Add(id);
            }
        }

            private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tv1.Text);
            DDetalleOrdenTrabajo.DeleteDetalleOrdenTrabajo(id);
            button6_Click(sender, e); // Es para refrescar los campos (llama al GetAll)
            MessageBox.Show("Borrado con exito");
            VaciarCampos();

        }
    }
}

        

