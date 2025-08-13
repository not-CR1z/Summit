
using Oracle.ManagedDataAccess.Client;
using SummitChallenges.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace SummitChallenges.Repositories

{
    public class ConnectionBD
    {
        private readonly string connectionString;
        public ConnectionBD()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            connectionString = config.GetConnectionString("oracleConnection") ?? throw new InvalidOperationException("Connection string not found.");
        }

        public User? LoginQuery(String login)
        {

            string userIdScript = $"SELECT ID FROM SIF.USERS WHERE LOGIN = '{login}'";
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand idcmd = new OracleCommand(userIdScript, conn))
                    {
                        var id = idcmd.ExecuteScalar();
                        if (id != null)
                        {
                            User retrieveUser = new User();

                            string _userDetailsScript =
                                "SELECT BU.USER_ID, BU.FIRST_NAME, BU.LAST_NAME, BU.T_SSN, R.NAME AS ROLE_NAME " +
                                "FROM BANCOL.USERS BU " +
                                "JOIN SIF.USER_ROLES UR ON BU.USER_ID = UR.USER_ID " +
                                "JOIN SIF.ROLES R ON UR.ROLE_ID = R.ID WHERE BU.USER_ID = :UserId";

                            using (OracleCommand usercmd = new OracleCommand(_userDetailsScript, conn))
                            {
                                usercmd.Parameters.Add(new OracleParameter(":UserId", OracleDbType.Int32) { Value = id });

                                using (OracleDataReader reader = usercmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        retrieveUser.Id = Convert.ToInt64(reader["USER_ID"]);
                                        retrieveUser.FirstName = reader["FIRST_NAME"]?.ToString() ?? string.Empty;
                                        retrieveUser.LastName = reader["LAST_NAME"]?.ToString() ?? string.Empty;
                                        retrieveUser.Documento = reader["T_SSN"]?.ToString() ?? string.Empty;
                                        retrieveUser.Role = reader["ROLE_NAME"]?.ToString() ?? string.Empty;

                                        return retrieveUser;
                                    }
                                }
                            }
                        }
                    return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }

}
