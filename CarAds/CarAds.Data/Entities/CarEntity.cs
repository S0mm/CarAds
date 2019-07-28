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
        public decimal Price { get; set; }

        public int UserId { get; set; }
        public int ConditionTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int GearBoxTypeId { get; set; }
        public int CarBrandId { get; set; }
        public int CarBrandModelId { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual ConditionTypeEntity ConditionType { get; set; }
        public virtual FuelTypeEntity FuelType { get; set; }
        public virtual GearBoxTypeEntity GearBoxType { get; set; }
        public virtual CarBrandEntity CarBrand { get; set; }
        public virtual CarBrandModelEntity CarBrandModel { get; set; }
    }
}