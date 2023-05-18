using System.ComponentModel.DataAnnotations;

namespace ParkingLot.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string IdentificationNumber { get; set; }
        public string Phone { get; set; }
    }
}
