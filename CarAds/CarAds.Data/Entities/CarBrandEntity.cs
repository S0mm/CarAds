using System.Collections.Generic;

namespace CarAds.Data.Entities
{
    public class CarBrandEntity
    {
        public CarBrandEntity()
        {
            Models = new List<CarBrandModelEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CarBrandModelEntity> Models { get; set; }
    }
}
