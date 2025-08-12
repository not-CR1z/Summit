
using Oracle.ManagedDataAccess.Client;
namespace SummitChallenges.Repositories

{
    public class ConnectionBD
    {
        private string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=wolf-rds-dev.apps.ambientesbc.com)(PORT=50214)))(CONNECT_DATA=(SERVICE_NAME=SIFNDCD)));User Id=cedurang;Password=Gato_2028";
        private string _fScript = "SELECT * FROM BANCOL.USERS WHERE USER_ID = 5620000000080";

        public void ExecuteQuery()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    conn.Open();
                    Console.WriteLine("Conexión exitosa a la base de datos Oracle");

                    // Crear un comando SQL para ejecutar una consulta
                    using (OracleCommand cmd = new OracleCommand(_fScript, conn))
                    {
                        // Ejecutar la consulta y obtener un lector de datos
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            // Leer los resultados
                            while (reader.Read())
                            {
                                // Imprimir los datos de cada fila (puedes acceder por índice o por nombre de columna)
                                Console.WriteLine($"NAME: {reader["FIRST_NAME"]}, LastName: {reader["LAST_NAME"]}, DOCUMENTO: {reader["T_SSN"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, lo mostramos 
                    Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
                }
                finally
                {
                    // Asegurarse de cerrar la conexión cuando termine
                    conn.Close();
                    Console.WriteLine("Conexión cerrada");
                }
                // Add logic to execute queries or interact with the database here  
            }
        }
    }

}

