namespace CarAds.Api.Models.ActionModels
{
    public class CarActionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int YearOfManufacture { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }

        public int UserId { get; set; }
        public int ConditionTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int GearBoxTypeId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
    }
}
