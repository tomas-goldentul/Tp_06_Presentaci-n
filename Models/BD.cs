using Microsoft.Data.SqlClient;
using Dapper;
class BD{
    private static string _connectionString = @"Server=localhost; DataBase SitioWeb; Integrated Security=True; TrustServerCertificate=True;";
        List<Integrante> integantes = new List<Integrante>();
public List<Integrante> ObtenerIntegrantes(){
 using(SqlConnection connection = new SqlConnection(_connectionString)){
    string query = "SELECT * FROM Integrantes";
    integantes = connection.Query<Integrante>(query).ToList();
 }
 return integantes;
}
public Integrante verificarCuenta(string usuarioIngresar, string contraseñaIngresar){
    Integrante integranteBuscado = null;
for(int i = 0; i < integantes.Count; i++){
    if(integantes[i].Username == usuarioIngresar && integantes[i].Password == contraseñaIngresar){
       integranteBuscado = integantes[i];
}

}
return integranteBuscado;
}
}