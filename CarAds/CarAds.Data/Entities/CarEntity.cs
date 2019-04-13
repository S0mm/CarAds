namespace CarAds.Data.Entities
{
    public class CarEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int YearOfManufacture { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        
        public ConditionTypeEntity ConditionType { get; set; }
        public FuelTypeEntity FuelType { get; set; }
        public GearBoxTypeEntity GearBoxType { get; set; }
        public UserEntity User { get; set; }
    }
}