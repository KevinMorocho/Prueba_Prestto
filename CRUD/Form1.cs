using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;

            string sql = "INSERT INTO cliente (id, nombreCliente, apellidoCliente, direccionCliente, emailCliente, telefonoCliente) VALUES('" + id + "','" + nombre + "','" + apellido + "','" + direccion + "','" + email + "','" + telefono + "')";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registrado con EXITO");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("EROR AL GUARDAR: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            MySqlDataReader reader =null;

            string sql = "SELECT id, nombreCliente, apellidoCliente, direccionCliente, emailCliente, telefonoCliente WHERE id LIKE'" + id + "' limit 1";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtId.Text = reader.GetString(0);
                        txtNombre.Text = reader.GetString(1);
                        txtApellido.Text = reader.GetString(2);
                        txtDireccion.Text = reader.GetString(3);
                        txtEmail.Text = reader.GetString(4);
                        txtTelefono.Text = reader.GetString(5);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR AL BUSCAR " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;

            string sql = "UPDATE cliente SET nombreCliente='" + nombre + "',apellidoCliente='" + apellido + "',direccionCliente='" + direccion + "',emailCliente='" + email + "',telefonoCliente='" + telefono + "' WHERE id='" + id + "'";
            
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Modificado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR AL MODIFICAR: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            

            string sql = "DELETE FROM cliente WHERE id='" + id + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro elimando con  EXITO");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR AL ELIMINAR: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }
        
    }
}
