namespace CarAds.Services.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int YearOfManufacture { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public ConditionType ConditionType { get; set; }
        public FuelType FuelType { get; set; }
        public GearBoxType GearBoxType { get; set; }
        public Brand Brand { get; set; }
        public BrandModel BrandModel { get; set; }
    }
}