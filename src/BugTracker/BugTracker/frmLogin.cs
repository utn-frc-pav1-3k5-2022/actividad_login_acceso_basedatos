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

namespace BugTracker
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Se debe ingresar un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Se debe ingresar una contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (ValidarCredenciales(txtUsuario.Text, txtPassword.Text))
            {
                MessageBox.Show("Usted a ingresado al sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();
            }
            else
            {
                txtUsuario.Text = "";
                txtPassword.Text = "";
                MessageBox.Show("Debe ingresar usuario y/o contraseña válidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidarCredenciales(string pUsuario, string pPassword)
        {

            //Inicializamos la variable usuarioValido en false, para que solo si el usuario es valido retorne true
            bool UsuarioValido = false;

            //Creamos una coneccion a una Base de datos nueva
            SqlConnection conexion = new SqlConnection();

            //Definimos la cadena de conexion a la BD
            conexion.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=BugTracker;Integrated Security=true;";

            //La setencia try ... catch nos permite "atrapar" exepciones (Errores) y mostrar un mensaje mas amigable 

            try
            {
                //Construimos la consulta sql para buscar el usuario en la BD
                String consultaSQL = String.Concat("Select * From Usuarios Where usuario='", pUsuario, "'");

                //Usuando el metodo GetDataManager obtenemos la instancia unica de DataManager (Patron Singleton) y ejecutamos el metodo ConsultaSQL()
                DataTable resultado = DataManager.GetInstance().ConsultaSQL(consultaSQL);

                //Validamos que el resultado tenga al menos una fila.
                if (resultado.Rows.Count >= 1)
                {

                    //En caso de que exista el usuario, validamos que password corresponda al usuario
                    if (resultado.Rows[0]["password"].ToString() == pPassword)
                    {

                        UsuarioValido=true;

                    }

                }

                /* ---------------------------------------------------Codigo sin la clase DataManager ------------------------------------------------------------------
                //Abrimos la coneccion a la base de datos
                conexion.Open();

                //Construimos la consulta sql para buscar el usuario en la BD
                string consultaSql = string.Concat("Select * From Usuarios Where usuario= '", pUsuario, "'");

                //Creamos un objeto command para poder realizar dicha consulta a la BD
                SqlCommand command = new SqlCommand(consultaSql, conexion);

                //El metodo ExecuteReader retorna un objeto SqlDataReader con la respuesta a la BD
                //Con sqlDataReader los datos se leen fila por fila, cambiando de fila cada vez que se ejecuta el metodo Read()
                SqlDataReader reader = command.ExecuteReader();

                //Ell metodo Read() lee la primera fila disponible, si NO existe una fila retorna false (la consulta no devolvio resultados).
                if (reader.Read())
                {

                    //En caso que exista el usuario, validamos que password corresponda al usuario
                    if (reader["password"].ToString() == pPassword)
                    {

                        UsuarioValido = true;

                    }


                }
                -------------------------------------------------------------------------------------------------------------------------------------------------------------*/

            }

            catch (SqlException ex)
            {

                //Mostramos un mensaje de error, indicando que hubo un error en la BD
                MessageBox.Show(String.Concat("Error de base de datos: ", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            /*
            finally
            {

                //Preguntamos si el estado de la conexion es abierto antes de cerrar la cconexion.
                if(conexion.State == ConnectionState.Open)
                {

                    //Cerramos la conexion
                    conexion.Close();

                }

            }
            */

            //retornamos el valor de usuarioValido.
            return UsuarioValido;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }

}
