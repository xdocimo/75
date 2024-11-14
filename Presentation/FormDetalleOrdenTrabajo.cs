using Datos;
using Modelos;
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




        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var detalles = DDetalleOrdenTrabajo.GetAll();

                dt1.Rows.Clear();

                // Configura el formato de la columna Cantidad
                dt1.Columns["Cantidad"].DefaultCellStyle.Format = "N2";

                foreach (var detalle in detalles)
                {
                    // Obtén los datos necesarios de la orden de trabajo
                    var ordenDeTrabajo = detalle.ordenDeTrabajo;
                    var fechaLote = ordenDeTrabajo.fechaLote.ToShortDateString();
                    var centroDeCostoDescripcion = ordenDeTrabajo.centroDeCosto.descripcion;

                    // Formatea la información de orden de trabajo
                    string ordenTrabajoInfo = $"ID: {ordenDeTrabajo.id} | Fecha: {fechaLote} | Centro: {centroDeCostoDescripcion}";

                    // Añade los datos al DataGridView
                    dt1.Rows.Add(
                        detalle.id,
                        ordenTrabajoInfo,          // Columna para orden de trabajo con detalle
                        detalle.insumo.detalle,     // Nombre del insumo
                        detalle.cantidad            // Cantidad
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }






        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tv1.Text))
            {
                try
                {

                    int id = Convert.ToInt32(tv1.Text);


                    var detalle = DDetalleOrdenTrabajo.GetById(id);


                    dt1.Rows.Clear();


                    if (detalle != null && detalle.id != 0) // Agregada la condicional esto por el BUG de los ceros
                    {

                        dt1.Rows.Add(detalle.id, detalle.ordenDeTrabajo.id, 
                                detalle.insumo.detalle, detalle.cantidad);

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
                try
                {
                    // Obtener el ID del detalle de orden de trabajo que se va a modificar
                    int id = Convert.ToInt32(tv1.Text);

                    // Obtener el ID de la Orden de Trabajo seleccionada usando `ObtenerIdOrdenTrabajoSeleccionada`
                    int ordenDeTrabajoId = ObtenerIdOrdenTrabajoSeleccionada();
                    if (ordenDeTrabajoId == -1)
                    {
                        MessageBox.Show("Por favor, selecciona una orden de trabajo válida.");
                        return;
                    }

                    // Obtener el nombre del insumo desde el ComboBox
                    string insumoNombre = cb2.Text;
                    decimal cantidad = Convert.ToDecimal(tv2.Text);

                    // Obtener los objetos completos (OrdenTrabajo e Insumo)
                    OrdenTrabajo ordenDeTrabajo = DDetalleOrdenTrabajo.GetOrdenTrabajoById(ordenDeTrabajoId);
                    Insumo insumo = DDetalleOrdenTrabajo.GetInsumoByNombre(insumoNombre); // Usa el método para obtener insumo por nombre

                    // Actualizar el detalle de la orden de trabajo
                    DDetalleOrdenTrabajo.UpdateDetalleOrdenTrabajo(id, ordenDeTrabajo, insumo, cantidad);

                    MessageBox.Show("Actualizado con éxito");
                    VaciarCampos();
                    button6_Click(sender, e); // Refresca los campos llamando a `GetAll`
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos antes de actualizar.");
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
            var insumos = DDetalleOrdenTrabajo.GetAllInsumos(); // Nuevo método para obtener todos los insumos
            cb2.Items.Clear();
            foreach (var insumo in insumos)
            {
                cb2.Items.Add(insumo.detalle); // Agrega el nombre (detalle) del insumo al ComboBox
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CamposCompletos())
            {
                try
                {
                    // Obtener el ID de la Orden de Trabajo seleccionada usando el método `ObtenerIdOrdenTrabajoSeleccionada`
                    int ordenDeTrabajoId = ObtenerIdOrdenTrabajoSeleccionada();
                    if (ordenDeTrabajoId == -1)
                    {
                        MessageBox.Show("Por favor, selecciona una orden de trabajo.");
                        return;
                    }

                    // Obtener el nombre del insumo desde el ComboBox
                    string insumoNombre = cb2.Text;
                    decimal cantidad = Convert.ToDecimal(tv2.Text);

                    // Obtener los objetos completos (OrdenTrabajo e Insumo)
                    OrdenTrabajo ordenDeTrabajo = DDetalleOrdenTrabajo.GetOrdenTrabajoById(ordenDeTrabajoId);
                    Insumo insumo = DDetalleOrdenTrabajo.GetInsumoByNombre(insumoNombre); // Usa un método para obtener insumo por nombre

                    // Insertar el detalle de la orden de trabajo
                    DDetalleOrdenTrabajo.InsertDetalleOrdenTrabajo(ordenDeTrabajo, insumo, cantidad);

                    MessageBox.Show("Detalle de orden de trabajo insertado con éxito.");
                    VaciarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Grave: " + ex.Message);
                }

                // Refresca los campos llamando al método `GetAll`
                button6_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Faltan completar campos");
            }
        }



        public void LoaderComboOrdenTrabajo()
        {
            var ordenesTrabajo = DDetalleOrdenTrabajo.GetAllOrdenesTrabajo();
            cb1.Items.Clear();

            // Recorre la lista de órdenes de trabajo y añade cada una al ComboBox
            foreach (var orden in ordenesTrabajo)
            {
                // Formato deseado: "ID: 1 | (FechaLote) | (Descripción de centroCosto)"
                string displayText = $"ID: {orden.id} | {orden.fechaLote.ToShortDateString()} | {orden.centroDeCosto.descripcion}";

                // Añade el KeyValuePair al ComboBox
                cb1.Items.Add(new KeyValuePair<int, string>(orden.id, displayText));
            }

            // Configura el ComboBox para mostrar el texto del Value y utilizar el Key como valor
            cb1.DisplayMember = "Value";
            cb1.ValueMember = "Key";
        }

        // Método para obtener el ID seleccionado
        public int ObtenerIdOrdenTrabajoSeleccionada()
        {
            if (cb1.SelectedItem is KeyValuePair<int, string> selectedPair)
            {
                return selectedPair.Key; // Retorna el ID seleccionado
            }
            return -1; // Retorna -1 si no hay selección
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tv1.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID para eliminar.");
                return;
            }

            try
            {
                int id = Convert.ToInt32(tv1.Text);
                DDetalleOrdenTrabajo.DeleteDetalleOrdenTrabajo(id);
                button6_Click(sender, e); // Refresca los campos (llama a GetAll)
                MessageBox.Show("Borrado con éxito");
                VaciarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("El ID debe ser un número válido.");
            }
        }

        private void dt1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}




