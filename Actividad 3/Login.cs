using System.Data;
using System.Data.SqlClient;

namespace Actividad_3;

public class DataManager
{


    private static DataManager instance;
    private string string_conexion;

    public DataManager()
    {
        string_conexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=BugTracker81940;Integrated Security=true;";

    }

    public static DataManager GetInstance()
    {
        if (instance == null)
            instance = new DataManager();

        return instance;
    }

    /// Resumen:
    ///      Se utiliza para sentencias SQL del tipo “Select” con parámetros recibidos desde la interfaz
    ///      La función recibe por valor una sentencia sql como string y un diccionario de objetos como parámetros
    /// Devuelve:
    ///      un objeto de tipo DataTable con el resultado de la consulta
    /// Excepciones:
    ///      System.Data.SqlClient.SqlException:
    ///          El error de conexión se produce:
    ///              a) durante la apertura de la conexión
    ///              b) durante la ejecución del comando.
    public DataTable ConsultaSQL(string strSql, Dictionary<string, object>? prs = null)
    {

        SqlConnection dbConnection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataTable tabla = new DataTable();
        try
        {

            dbConnection.ConnectionString = string_conexion;
            dbConnection.Open();
            cmd.Connection = dbConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;

            //Agregamos a la colección de parámetros del comando los filtros recibidos
            if (prs != null)
            {
                foreach (var item in prs)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }
            }

            tabla.Load(cmd.ExecuteReader());
            return tabla;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    /// Resumen:
    ///     Se utiliza para sentencias SQL del tipo “Insert/Update/Delete”. Recibe por valor una sentencia sql como string
    /// Devuelve:
    ///      un valor entero con el número de filas afectadas por la sentencia ejecutada
    /// Excepciones:
    ///      System.Data.SqlClient.SqlException:
    ///          El error de conexión se produce:
    ///              a) durante la apertura de la conexión
    ///              b) durante la ejecución del comando.
    public int EjecutarSQL(string strSql, Dictionary<string, object>? prs = null)
    {
        // Se utiliza para sentencias SQL del tipo “Insert/Update/Delete”
        SqlConnection dbConnection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        int rtdo = 0;

        // Try Catch Finally
        // Trata de ejecutar el código contenido dentro del bloque Try - Catch
        // Si hay error lo capta a través de una excepción
        // Si no hubo error
        try
        {
            dbConnection.ConnectionString = string_conexion;
            dbConnection.Open();
            cmd.Connection = dbConnection;
            cmd.CommandType = CommandType.Text;
            // Establece la instrucción a ejecutar
            cmd.CommandText = strSql;

            //Agregamos a la colección de parámetros del comando los filtros recibidos
            if (prs != null)
            {
                foreach (var item in prs)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }
            }

            // Retorna el resultado de ejecutar el comando
            rtdo = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rtdo;
    }


    /// Resumen:
    ///     Se utiliza para sentencias SQL del tipo “Select”. Recibe por valor una sentencia sql como string
    /// Devuelve:
    ///      un valor entero
    /// Excepciones:
    ///      System.Data.SqlClient.SqlException:
    ///          El error de conexión se produce:
    ///              a) durante la apertura de la conexión
    ///              b) durante la ejecución del comando.
    public object ConsultaSQLScalar(string strSql)
    {
        SqlConnection dbConnection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        try
        {
            dbConnection.ConnectionString = string_conexion;
            dbConnection.Open();
            cmd.Connection = dbConnection;
            cmd.CommandType = CommandType.Text;
            // Establece la instrucción a ejecutar
            cmd.CommandText = strSql;
            return cmd.ExecuteScalar();
        }
        catch (SqlException ex)
        {
            throw (ex);
        }
    }

}

public partial class Login : Form
{
    public Login()
    {
        InitializeComponent();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        //validamos que se haya ingresado un Usuario
        if (txtUser.Text == "")
        {
            MessageBox.Show("Se debe ingresar un usuario.");
            return;
        }

        //validamos que se haya ingresado una contraseña
        if (txtPassword.Text == "")
        {
            MessageBox.Show("Se debe ingresar una contraseña.");
            return;
        }

        if (ValidarCredenciales(txtUser.Text, txtPassword.Text))
        {
            MessageBox.Show("Usted a ingresado al sistema.");
            this.Close();
        }
        else 
        {
            txtUser.Text = "";
            txtPassword.Text = "";
            MessageBox.Show("Usuario y/o contraseña incorrextos.");
        }
    }

    public bool ValidarCredenciales(string txtUser, string txtPassword)
    {
        //Inicializamos la variable usuarioValido en false, para que solo si el usuario es valido retorne true
        bool usuarioValido = false;

        //La doble barra o */ nos permite escribir comentarios sobre nuestro codigo sin afectar su funcionamiento.

        //La sentencia try...catch nos permite "atrapar" excepciones (Errores) y dar al usuario un mensaje más amigable.
        try
        {

            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String consultaSql = string.Concat(" SELECT * ",
                                               "   FROM Usuarios ",
                                               "  WHERE usuario =  '", txtUser, "'");

            //Usando el método GetDataManager obtenemos la instancia unica de DataManager (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            DataTable resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);

            //Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count >= 1)
            {
                //En caso de que exista el usuario, validamos que password corresponda al usuario
                if (resultado.Rows[0]["password"].ToString() == txtPassword)
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

        // Retornamos el valor de usuarioValido. 
        return usuarioValido;
    }




    private void btnExit_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}