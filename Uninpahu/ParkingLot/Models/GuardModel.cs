using System.ComponentModel.DataAnnotations;

namespace ParkingLot.Models
{
    public class GuardModel
    {
        public int IdGuard { get; set; }
        public int IdPerson { get; set; }
        public required string GuardUserName { get; set; }
        [DataType(DataType.Password)]
        public required string GuardPassword { get; set; }
    }
}
