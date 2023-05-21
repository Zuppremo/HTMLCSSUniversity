using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using ParkingLot.Models;
using System.Data;

namespace ParkingLot.Controllers.REST_API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorbikeController
    {
        private readonly IConfiguration configuration;
        public MotorbikeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT  id_motorbike, motorbike_plate, motorbike_model, id_motorbikeBrand FROM motorbike";

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
        public JsonResult GetOneMotorbike(int id)
        {
            string query = @"SELECT id_motorbike, motorbike_plate, motorbike_model, id_motorbikeBrand FROM motorbike_brand WHERE id_motorbike =?Id;";

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
        public JsonResult Post(Motorbike motorbike)
        {
            string query = @"INSERT INTO motorbike (motorbike_plate, motorbike_model, id_motorbikeBrand) 
                             VALUES (?Plate, ?Model, ?IdMotorbikeBrand);";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("?Plate", motorbike.Plate);
                    myCommand.Parameters.AddWithValue("?Model", motorbike.Model);
                    myCommand.Parameters.AddWithValue("?IdMotorbikeBrand", motorbike.IdMotorbikeBrand);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Motorbike added sucessfully");
        }

        [HttpPut]
        public JsonResult Put(Motorbike motorbike)
        {
            string query = @"UPDATE motorbike SET motorbike_plate =?Plate, motorbike_model =?Model, id_motorbikeBrand =?IdMotorbikeBrand WHERE id_motorbikebrand =?Id;";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("?Id", motorbike.Id);
                    myCommand.Parameters.AddWithValue("?Plate", motorbike.Plate);
                    myCommand.Parameters.AddWithValue("?Model", motorbike.Model);
                    myCommand.Parameters.AddWithValue("?IdMotorBikeBrand", motorbike.IdMotorbikeBrand);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Motorbike updated sucessfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"DELETE FROM motorbike WHERE id_motorbike =?Id;";

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
            return new JsonResult("Motorbike deleted sucessfully");
        }
    }
}
