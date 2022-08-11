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
            conexion.ConnectionString = "Data Source=maquis;Initial Catalog=BugTracker;User ID=avisuales1;Password=Pav1#2020Maquis";

            //La setencia try ... catch nos permite "atrapar" exepciones (Errores) y mostrar un mensaje mas amigable 

            try
            {

                //Abrimos la coneccion a la base de datos
                conexion.Open();

                //Construimos la consulta sql para buscar el usuario en la BD
                string consultaSql = string.Concat("Select * From Usuarios Where usuario= '", pUsuario, "'");

                //Creamos un objeto command para poder realizar dicha consulta a la BD
                SqlCommand command = 

            }

            return true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }

}
