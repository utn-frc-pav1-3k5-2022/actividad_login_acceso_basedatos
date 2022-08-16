namespace BugTracker
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string validacion = this.ValidarCadenas(this.txtUsuario.Text, this.txtContrasena.Text);
            if (!string.IsNullOrEmpty(validacion))
                MessageBox.Show(validacion, "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Ingreso correcto al sistema", "Ingreso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string ValidarCadenas(string usuario, string contrasena)
        {
            if (string.IsNullOrEmpty(this.txtContrasena.Text) && string.IsNullOrEmpty(this.txtUsuario.Text))
                return "Ingrese usuario y contraseña";
            if (!this.ValidarCredenciales(usuario, contrasena))
                return "Usuario y contraseña incorrecto";
            else
                return null;
        }

        private bool ValidarCredenciales(string usuario, string contrasena)
        {
            string query = "SELECT * FROM USUARIOS WHERE 1 = 1 AND usuario = @usuario AND password = @password";
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("usuario", usuario);
            parametros.Add("password", contrasena);

            return DataManager.GetInstance().ConsultaSQL(query, parametros).Rows.Count == 1;
            
        }

        private void btnMostrarContrasena_Click(object sender, EventArgs e)
        {
            this.txtContrasena.Focus();
            if (this.txtContrasena.PasswordChar == '*')
            {
                this.btnMostrarContrasena.BackgroundImage = global::BugTracker.Properties.Resources.OjoCerrado;
                this.txtContrasena.PasswordChar = '\0';
            }
            else
            {
                this.btnMostrarContrasena.BackgroundImage = global::BugTracker.Properties.Resources.OjoAbierto;
                this.txtContrasena.PasswordChar = '*';
            }
            
        }
    }
}