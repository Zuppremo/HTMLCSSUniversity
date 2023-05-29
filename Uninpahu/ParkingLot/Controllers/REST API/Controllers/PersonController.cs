using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using ParkingLot.Models;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace ParkingLot.Controllers.REST_API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController
    {
        private readonly IConfiguration configuration;
        public PersonController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        [HttpGet("last")]
        public JsonResult GetLastId()
        {
            string query = @"SELECT MAX(id_person) FROM person";
            object a;
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    a = myCommand.ExecuteScalar();
                    Console.WriteLine(a.ToString());
                    myCon.Close();
                }
            }
            return new JsonResult(a);
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT  id_person, person_name, person_email, person_IDNumber, person_PhoneNumber FROM person";

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
        

        [HttpGet("{id}")]
        public JsonResult GetOnePerson(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException("id", "Id must be a positive integer.");
                }

                string query = @"SELECT id_person, person_name, person_email, person_IDNumber, person_PhoneNumber FROM person WHERE id_person = ?Id;";

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
            catch (MySqlException ex)
            {
                // Perform custom error handling here
                return new JsonResult(ex.Message);
            }
            catch (Exception ex)
            {
                // Perform custom error handling here
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult Post(PersonModel person)
        {
            string query = @"INSERT INTO person (person_name, person_email, person_IDNumber, person_PhoneNumber) 
                             VALUES (?Name, ?Email, ?IdentificationNumber, ?Phone);";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("?Name", person.Name);
                    myCommand.Parameters.AddWithValue("?Email", person.Email);
                    myCommand.Parameters.AddWithValue("?IdentificationNumber", person.IdentificationNumber);
                    myCommand.Parameters.AddWithValue("?Phone", person.Phone);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Person added sucessfully");
        }

        [HttpPut]
        public JsonResult Put(PersonModel person)
        {
            string query = @"UPDATE person SET person_name =?Name, person_email =?Email, person_IDNumber =?IdentificationNumber,
                             person_PhoneNumber =?Phone WHERE id_person =?Id;";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("?Id", person.Id);
                    myCommand.Parameters.AddWithValue("?Name", person.Name);
                    myCommand.Parameters.AddWithValue("?Email", person.Email);
                    myCommand.Parameters.AddWithValue("?IdentificationNumber", person.IdentificationNumber);
                    myCommand.Parameters.AddWithValue("?Phone", person.Phone);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Person updated sucessfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"DELETE FROM person WHERE id_person =?Id;";

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
            return new JsonResult("Deleted sucessfully");
        }
    }
}
