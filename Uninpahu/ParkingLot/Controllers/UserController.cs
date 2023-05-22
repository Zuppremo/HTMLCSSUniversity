 using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using ParkingLot.Controllers.REST_API;
using ParkingLot.Models;
using System.Configuration;

namespace ParkingLot.Controllers
{
    public class UserController : Controller
    {
        private ILogger<UserController> _logger;
        private IConfiguration _configuration;
        public UserController(ILogger<UserController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            string sqlDataSource = _configuration.GetConnectionString("databaseConnection");
            List<PersonModel> persons = new List<PersonModel>();
            using (MySqlConnection con = new MySqlConnection(sqlDataSource))
            {
                string query = "SELECT  id_person, person_name, person_email, person_IDNumber, person_PhoneNumber FROM person";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            persons.Add(new PersonModel
                            {
                                Id = sdr.GetInt32(0),
                                Name = sdr["person_name"].ToString(),
                                Email = sdr["person_email"].ToString(),
                                IdentificationNumber = sdr["person_IDNumber"].ToString(),
                                Phone = sdr["person_PhoneNumber"].ToString(),
                            });
                        }
                    }
                }
            }
            return View(persons);

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }


    }
}
