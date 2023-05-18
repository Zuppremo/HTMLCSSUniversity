using System.ComponentModel.DataAnnotations;

namespace ParkingLot.Models
{
    public class AdministratorModel
    {
        public int IdAdministrator { get; set; }
        public int IdPerson { get; set; }
        public required string AdministratorUserName { get; set; }
        [DataType(DataType.Password)]
        public required string AdministratorPassword { get; set; }
    }
}
