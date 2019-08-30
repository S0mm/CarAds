using System.ComponentModel.DataAnnotations;

namespace CarAds.Api.Models.ActionModels
{
    public class CarActionModel
    {
        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int? YearOfManufacture { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int? Mileage { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public int? UserId { get; set; }

        [Required]
        public int? ConditionTypeId { get; set; }

        [Required]
        public int? FuelTypeId { get; set; }

        [Required]
        public int? GearBoxTypeId { get; set; }

        [Required]
        public int? BrandId { get; set; }

        [Required]
        public int? ModelId { get; set; }
    }
}
