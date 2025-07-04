using Microsoft.Data.SqlClient;
using Dapper;
public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=SitioWeb; Integrated Security=True; TrustServerCertificate=True;";
    public static List<Integrante> integrantes = new List<Integrante>();
    public static List<Integrante> ObtenerIntegrantes()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            
            string query = "SELECT * FROM Integrantes";
            integrantes = connection.Query<Integrante>(query).ToList();
        }
        return integrantes;
    }
    public static Integrante verificarCuenta(string usuarioIngresar, string contraseñaIngresar)
    {
        Integrante integranteBuscado = null;
        for (int i = 0; i < integrantes.Count; i++)
        {
            if (integrantes[i].Username == usuarioIngresar && integrantes[i].Password == contraseñaIngresar)
            {
                integranteBuscado = integrantes[i];
            }
        }
        return integranteBuscado;
    }
}