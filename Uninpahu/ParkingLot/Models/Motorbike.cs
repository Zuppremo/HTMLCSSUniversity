namespace ParkingLot.Models
{
    public class Motorbike
    {
        public int IdMotorbike { get; set;}
        public required string MotorbikePlate { get; set; }
        public int MotorbikeModel { get; set; }
        public int IdMotorbikeBrand { get; set; }
    }
}
