using System.ComponentModel.DataAnnotations;

namespace ParkingLotMotorbikeUninpahu.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string IdentificationNumber { get; set; }
        public string Phone { get; set; }

    }
}
