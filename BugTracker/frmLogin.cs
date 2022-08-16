using BugTracker.Acceso_a_datos;//agregado
using System.Data;//agregado
using System.Data.SqlClient;//agregado

namespace BugTracker
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOcultarMostrarContrasenia_Click(object sender, EventArgs e)
        {
            OcultarMostrarContrasenia();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == String.Empty)
            {
                MessageBox.Show("Debe ingresar un Usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtContrasenia.Text == String.Empty)
            {
                MessageBox.Show("Debe ingresar una Contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (ValidarCredenciales(txtUsuario.Text, txtContrasenia.Text))
                {
                    MessageBox.Show("Usted a Ingresado al Sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña incorrecto", "Error de Ingreso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro que quiere salir del Sitema?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //METODOS

        private void OcultarMostrarContrasenia()
        {
            if (txtContrasenia.PasswordChar == '*')
            { 
                txtContrasenia.PasswordChar = '\0';
                this.btnOcultarMostrarContrasenia.BackgroundImage = global::BugTracker.Properties.Resources.ocultar;
            }
            else if (txtContrasenia.PasswordChar == '\0')
            { 
                txtContrasenia.PasswordChar = '*';
                this.btnOcultarMostrarContrasenia.BackgroundImage = global::BugTracker.Properties.Resources.mostrar;
            }
        }

        private bool ValidarCredenciales(string pUsuario, string pPassword)
        {
            //Inicializamos la variable usuarioValido en false, para que solo si el usuario es valido retorne true
            bool usuarioValido = false;

            //La sentencia try...catch nos permite "atrapar" excepciones (Errores) y dar al usuario un mensaje más amigable.
            try
            {
                //Construimos la consulta sql para buscar el usuario en la base de datos.
                String consultaSql = string.Concat(" SELECT * FROM Usuarios us",
                                                   " WHERE us.usuario LIKE '", pUsuario, "'");

                //Usando el método GetDataManager obtenemos la instancia unica de DataManager (Patrón Singleton) y ejecutamos el método ConsultaSQL()
                DataTable resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);

                //Validamos que el resultado tenga al menos una fila.
                if (resultado.Rows.Count >= 1)
                {
                    //En caso de que exista el usuario, validamos que password corresponda al usuario
                    if (resultado.Rows[0]["password"].ToString() == pPassword)
                    {
                        usuarioValido = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                //Mostramos un mensaje de error indicando que hubo un error en la base de datos.
                MessageBox.Show(string.Concat("Error de base de datos: ", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Retornamos el valor de usuarioValido.
            return usuarioValido;
        }
    }
}