using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace ParkingLot.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public int IdPerson { get; set; }
        public int IdMotorbike { get; set; }
        public int UserWorkingDay { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public required string UserPassword { get; set; }
        public int UserHasAccess { get; set; }

    }
}
