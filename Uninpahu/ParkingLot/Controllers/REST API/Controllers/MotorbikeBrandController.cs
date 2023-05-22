using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using ParkingLot.Models;
using System.Data;

namespace ParkingLot.Controllers.REST_API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorbikeBrandController : Controller
    {
        private readonly IConfiguration configuration;
        public MotorbikeBrandController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ActionResult Register()
        {
            List<MotorbikeBrand> brands = new List<MotorbikeBrand>();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");

            using (MySqlConnection con = new MySqlConnection(sqlDataSource))
            {
                string query = "SELECT  id_motorbikebrand, motorbikebrand_name FROM motorbikebrand";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            brands.Add(new MotorbikeBrand
                            {
                                Id = sdr.GetInt32(0),
                                Name = sdr["motorbikebrand_name"].ToString()
                            });
                        }
                    }
                }
            }
            return View(brands);
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT  id_motorbikebrand, motorbikebrand_name FROM motorbike_brand";

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
        public JsonResult GetOneMotorbikeBrand(int id)
        {
            string query = @"SELECT id_motorbikebrand, motorbikebrand_name FROM motorbike_brand WHERE id_motorbikebrand =?Id;";

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
        public JsonResult Post(MotorbikeBrand motorbikeBrand)
        {
            string query = @"INSERT INTO motorbike_brand (motorbikebrand_name) 
                             VALUES (?Name);";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("?Name", motorbikeBrand.Name);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Motorbike brand added sucessfully");
        }

        [HttpPut]
        public JsonResult Put(MotorbikeBrand motorbikeBrand)
        {
            string query = @"UPDATE motorbike_brand SET motorbikebrand_name =?Name WHERE id_motorbikebrand =?Id;";

            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("databaseConnection");
            MySqlDataReader myReader;

            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                Console.WriteLine(sqlDataSource);
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("?Id", motorbikeBrand.Id);
                    myCommand.Parameters.AddWithValue("?Name", motorbikeBrand.Name);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Brand updated sucessfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"DELETE FROM motorbike_brand WHERE id_motorbikebrand =?Id;";

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
            return new JsonResult("motorbike deleted sucessfully");
        }
    }
}
