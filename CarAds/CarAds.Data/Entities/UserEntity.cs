using System.Collections.Generic;

namespace CarAds.Data.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Cars = new List<CarEntity>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public virtual ICollection<CarEntity> Cars { get; set; }
    }
}