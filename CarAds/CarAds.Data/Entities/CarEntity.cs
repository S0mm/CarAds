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

        public int UserId { get; set; }
        public int ConditionTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int GearBoxTypeId { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual ConditionTypeEntity ConditionType { get; set; }
        public virtual FuelTypeEntity FuelType { get; set; }
        public virtual GearBoxTypeEntity GearBoxType { get; set; }
    }
}