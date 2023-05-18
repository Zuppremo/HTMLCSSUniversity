using System.ComponentModel.DataAnnotations;

namespace ParkingLot.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public int IdMotorbike { get; set; }
        public int IdPerson { get; set; }
        public int UserUserName { get; set; }
        [DataType(DataType.Password)]
        public required string UserPassword { get; set; }
        public bool UserHasAccess { get; set; }
    }
}
