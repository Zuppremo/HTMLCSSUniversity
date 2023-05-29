using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using ParkingLot.Models;
using System.Data;

namespace ParkingLot.Controllers.REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private readonly IConfiguration configuration;
        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT  id_user, id_person, username, user_password, user_has_access, user_workingday FROM user";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpGet("usercreds/{username}")]
        public JsonResult GetUsernameAndPassword(string userName)
        {
            string query = @"SELECT username, user_password FROM user WHERE username =?UserName";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("?UserName", userName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }


        [HttpGet("{id}")]
        public JsonResult GetOneUser(int id)
        {
            string query = @"SELECT  id_user, id_person, username, user_password, user_has_access, user_workingday FROM user WHERE id_user =?Id;";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("?Id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(User user)
        {
            string query = @"INSERT INTO user (id_person, id_motorbike, user_workingday, username, user_password, user_has_access) 
                             VALUES (?IdPerson, ?IdMotorbike, ?UserWorkingDay, ?UserName, ?UserPassword, ?UserHasAccess);";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("?IdPerson", user.IdPerson);
                    myCommand.Parameters.AddWithValue("?IdMotorbike", user.IdMotorbike);
                    myCommand.Parameters.AddWithValue("?UserWorkingDay", user.UserWorkingDay);
                    myCommand.Parameters.AddWithValue("?UserName", user.UserName);
                    myCommand.Parameters.AddWithValue("?UserPassword", user.UserPassword);
                    myCommand.Parameters.AddWithValue("?UserHasAccess", user.UserHasAccess);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("User added sucessfully");
        }


        [HttpPost("form")]
        public JsonResult PostForm(User user)
        {
            string query = @"INSERT INTO user (id_person, id_motorbike, user_workingday, username, user_password, user_has_access) 
                 VALUES ((SELECT MAX(id_person) FROM person), (SELECT MAX(id_motorbike) FROM motorbike), ?UserWorkingDay, ?UserName, ?UserPassword, ?UserHasAccess)";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("?UserWorkingDay", user.UserWorkingDay);
                    myCommand.Parameters.AddWithValue("?UserName", user.UserName);
                    myCommand.Parameters.AddWithValue("?UserPassword", user.UserPassword);
                    myCommand.Parameters.AddWithValue("?UserHasAccess", user.UserHasAccess);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("User added sucessfully");
        }


        [HttpPut]
        public JsonResult Put(User user)
        {
            string query = @"UPDATE user SET id_person =?IdPerson, id_motorbike =?IdMotorbike, user_workingday =?UserWorkingDay,
                             username =?UserName, user_password =?UserPassword, user_has_access =?UserHasAccess WHERE id_user =?Id;";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("?Id", user.IdUser);
                    myCommand.Parameters.AddWithValue("?IdPerson", user.IdPerson);
                    myCommand.Parameters.AddWithValue("?IdMotorbike", user.IdMotorbike);
                    myCommand.Parameters.AddWithValue("?UserWorkingDay", user.UserWorkingDay);
                    myCommand.Parameters.AddWithValue("?UserName", user.UserName);
                    myCommand.Parameters.AddWithValue("?UserPassword", user.UserPassword);
                    myCommand.Parameters.AddWithValue("?UserHasAccess", user.UserHasAccess);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("User updated sucessfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"DELETE FROM user WHERE id_user =?Id;";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("?Id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("User Deleted sucessfully");
        }
    }
}
