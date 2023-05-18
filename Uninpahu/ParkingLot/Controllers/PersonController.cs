using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using NuGet.Protocol.Plugins;
using ParkingLot.Models;
using System.Configuration;
using System.Net.NetworkInformation;

namespace ParkingLot.Controllers
{
    public class PersonController : Controller
    {
        private readonly MySqlConnectionStringBuilder builderMySql = new MySqlConnectionStringBuilder();
        public PersonController()
        {
            builderMySql.Server = "127.0.0.1";
            builderMySql.UserID = "zuppremodev";
            builderMySql.Database = "uninpahuparkinglot";
            builderMySql.Password = "deybi";
        }

        public ActionResult Index()
        {
            List<PersonModel> persons = new List<PersonModel>();
            using (MySqlConnection con = new MySqlConnection(builderMySql.ConnectionString))
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
        }
    }
}
