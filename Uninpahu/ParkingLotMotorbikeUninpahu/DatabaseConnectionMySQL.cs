using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ParkingLotMotorbikeUninpahu
{
    public class DatabaseConnectionMySQL
    {
        public void OpenSQLConnectionToDatabase()
        {
            string connectionString = "server=127.0.0.1;database=bda_2023;uid=zuppremodev;password=deybi;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public MySqlCommand CreateSQLQuery(string query, MySqlConnection connection)
        {
            //Example "SELECT * FROM persona";
            MySqlCommand command = new MySqlCommand(query, connection);
            return command;
        }

        public void ExecuteSQLQuery(MySqlCommand query)
        {
            MySqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                // Access the data using reader["column_name"] or reader.GetInt32(column_index)
                int id = reader.GetInt32(0);
                string name = reader["nombre_persona"].ToString();
                Console.WriteLine("ID: " + id + ", nombre: " + name);
            }
            reader.Close();
        }

        public void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
        }
    }
}
