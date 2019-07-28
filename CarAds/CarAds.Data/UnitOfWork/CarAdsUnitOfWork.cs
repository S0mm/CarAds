namespace CarAds.Data.UnitOfWork
{
    public class CarAdsUnitOfWork : UnitOfWork
    {
        public CarAdsUnitOfWork(CarAdsDbContext context) : base(context)
        {
        }
    }
}