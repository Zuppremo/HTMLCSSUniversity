namespace ParkingLot.Models
{
    public class Motorbike
    {
        public int Id { get; set;}
        public required string Plate { get; set; }
        public int Model { get; set; }
        public int IdMotorbikeBrand { get; set; }
    }
}
