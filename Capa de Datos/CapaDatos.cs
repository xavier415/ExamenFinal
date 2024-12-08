using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;


namespace Capa_de_Datos
{
    public class CapaDatos
    {
        
    private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Método para ejecutar un procedimiento almacenado que devuelve un valor
        public SqlDataReader ExecuteReader(string storedProcedure, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(storedProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        // Método para ejecutar un procedimiento almacenado sin esperar valor de retorno
        public void ExecuteNonQuery(string storedProcedure, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
