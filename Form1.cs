using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KioscoProductos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Producto prod1 = new Producto();

            if (txtNombre.Text == string.Empty || txt_Precio.Text == string.Empty)
            {
                MessageBox.Show("Ingrese datos para poder agregar");
            }
            else
            {
                prod1.nombreProdu = txtNombre.Text;
                prod1.precioProdu = float.Parse(txt_Precio.Text);

                int resultado = ProductoDal.Agregar(prod1);

                if (resultado > 0)
                {
                    MessageBox.Show("Datos guardados correctamente", "Dato guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error al guardar");
                }
            }

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            Producto pProducto = new Producto();

            if (txtNombre.Text == string.Empty || txt_Precio.Text == string.Empty)
            {
                MessageBox.Show("Ingrese datos para poder modificar");
            }
            else
            {
                pProducto.nombreProdu = txtNombre.Text;
                pProducto.precioProdu = float.Parse(txt_Precio.Text);
                int resultado = ProductoDal.Modificar(pProducto);

                if (resultado > 0)
                {
                    MessageBox.Show("Datos Cambiados correctamente", "Dato cambiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error al cambiar");
                }
            }

        }
        void limpiar()
        {
            txtNombre.Clear();
            txt_Precio.Clear();
            txt_Id.Clear();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)

        {
            Producto pProducto = new Producto();

            if (txtNombre.Text==string.Empty && txt_Precio.Text==string.Empty && txt_Id.Text == string.Empty)
            {
                MessageBox.Show("Ingrese ID para eliminar");
            }else 
            {
                pProducto.numeroProdu = int.Parse(txt_Id.Text);
                int resultado = ProductoDal.Eliminar(pProducto.numeroProdu);
                if (resultado > 0)
                {
                    MessageBox.Show("Datos borrados correctamente", "Dato borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error al borrar");
                }
            } 
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dvgBD.DataSource = ProductoDal.BuscarProducto(txtNombre.Text);
        }

        private void txt_Precio_TextChanged(object sender, EventArgs e)
        {
            dvgBD.DataSource = ProductoDal.BuscarProducto(txt_Precio.Text);
        }

        private void txt_Id_TextChanged(object sender, EventArgs e)
        {
            dvgBD.DataSource = ProductoDal.BuscarProducto(txtNombre.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dvgBD.DataSource = ProductoDal.BuscarProducto(txtNombre.Text);
        }
    }
}
