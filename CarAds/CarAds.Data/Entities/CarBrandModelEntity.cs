namespace CarAds.Data.Entities
{
    public class CarBrandModelEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CarBrandId { get; set; }

        public virtual CarBrandEntity CarBrand { get; set; }
    }
}
