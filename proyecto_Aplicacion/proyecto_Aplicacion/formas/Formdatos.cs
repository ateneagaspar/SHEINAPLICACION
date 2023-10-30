using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_Aplicacion.formas
{
    public partial class Formdatos : Form
    {
        public Formdatos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string color = txtColor.Text;
            string zapatos = cmbZapatos.Text;
            string prenda = cmbPrenda.Text;
            string presio = textBoxPresio.Text;
            string talla = cmbTalla.Text;
            string accesorios = cmbAccesorios.Text;
            string calzado = cmbCalzados.Text;
            
            bool datosincompletos = false;
            String mensajeIncorrecto = "corrija errores.\n";

            if(string.IsNullOrWhiteSpace(nombre))
            {
                datosincompletos = true;
                mensajeIncorrecto += "-El campo nombre no puede estar vacio.\n";
            }

            if(string.IsNullOrWhiteSpace(color))
            {
                datosincompletos = true;
                mensajeIncorrecto += "-el campo color no puede estar vacio.\n";
            }
             
            if(string.IsNullOrWhiteSpace(zapatos))
            {
                datosincompletos = true;
                mensajeIncorrecto += "-el campo zapatos no puede estar vacio.\n";
            }

            if(string.IsNullOrWhiteSpace(presio))
            {
                datosincompletos = true;
                mensajeIncorrecto += "-el campo presio no puede estar vacio.\n";
            }

            if(string.IsNullOrWhiteSpace(prenda))
            {
                datosincompletos = true;
                mensajeIncorrecto += "-el campo prenda no puede estar vacio.\n";
            }

            if(string.IsNullOrWhiteSpace(talla))
            {
                datosincompletos = true;
                mensajeIncorrecto += "-el campo talla no puede estar vacio.\n";
            }

            if(string.IsNullOrWhiteSpace(calzado))
            {
                datosincompletos = true;
                mensajeIncorrecto += "-el campo calzado no puede estar vacio.\n";
            }


            if(string.IsNullOrWhiteSpace(accesorios))
            {
                datosincompletos = true;
                mensajeIncorrecto += "-el campo accesorios no puede estar vacio.\n";
            }

            if(datosincompletos)
            {
                MessageBox.Show(mensajeIncorrecto, "incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else
            if (!decimal.TryParse(textBoxPresio.Text, out _))
            {
                MessageBox.Show("el campo precio debe contener solamente numeros.", "precio no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {



                    DataGridViewRow renglon = (DataGridViewRow)dataGridView1.Rows[0].Clone();

                    renglon.Cells[0].Value = txtNombre.Text; //primera columna
                    renglon.Cells[1].Value = cmbPrenda.Text; //segunda columna
                    renglon.Cells[2].Value = txtColor.Text; //tercera columna
                    renglon.Cells[3].Value = textBoxPresio.Text; //tercera columna
                    renglon.Cells[4].Value = cmbTalla.Text; //combox1
                    renglon.Cells[5].Value = cmbZapatos.Text; //sexta columna
                    renglon.Cells[6].Value = cmbAccesorios.Text; //combox2
                    renglon.Cells[7].Value = cmbCalzados.Text; //combox3

                    dataGridView1.Rows.Add(renglon); //Arreglando renglon 

                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Agregando nombre del solicitante",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mensaje = "desea eliminar el registro?";
            string titulo = "eliminando el registro";




            if (!(dataGridView1.CurrentRow is null))
            {
                if (MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {

                MessageBox.Show("selecciona un renglon", "eliminado dato", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) //En caso de que no exista renglón seleccionado...
            {
                MessageBox.Show("Primero debes seleccionar un renglón", "Modifocando Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                // copia llos valores extraidos de los textbox del datagridview
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
            cmbPrenda.SelectedItem = dataGridView1.CurrentRow.Cells["prenda"].Value.ToString();
            txtColor.Text = dataGridView1.CurrentRow.Cells["Color"].Value.ToString();
            cmbZapatos.SelectedItem  = dataGridView1.CurrentRow.Cells["zapatos"].Value.ToString();
            cmbTalla.SelectedItem = dataGridView1.CurrentRow.Cells["talla"].Value.ToString();
            textBoxPresio.Text = dataGridView1.CurrentRow.Cells["Presio"].Value.ToString();
            cmbCalzados.SelectedItem = dataGridView1.CurrentRow.Cells["calzados"].Value.ToString();
            cmbAccesorios.SelectedItem = dataGridView1.CurrentRow.Cells["accesorios"].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) &&
           string.IsNullOrWhiteSpace(txtColor.Text) &&

           
           cmbPrenda.SelectedItem == null &&
           cmbTalla.SelectedItem == null &&
           cmbAccesorios.SelectedItem == null &&
           cmbCalzados.SelectedItem == null &&
           cmbZapatos.SelectedItem == null &&
           string.IsNullOrWhiteSpace(textBoxPresio.Text))
            {
                MessageBox.Show("Nada que borrar", " no hay datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Si al menos uno de los TextBox contiene datos, limpia todos los TextBox.
                txtColor.Clear();
                txtNombre.Clear(); 
                textBoxPresio.Clear();
                cmbAccesorios.DataSource = null;
                cmbTalla.DataSource = null;
                cmbPrenda.DataSource = null;
                cmbZapatos.DataSource = null;
                cmbCalzados.DataSource = null;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormAyuda ayuda = new FormAyuda();
            ayuda.Show();
            Hide();
        }
    }
}






