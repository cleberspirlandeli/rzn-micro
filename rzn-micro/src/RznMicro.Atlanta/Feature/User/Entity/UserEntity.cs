using RznMicro.Atlanta.Common;
using RznMicro.Atlanta.Enumerable;
using RznMicro.Atlanta.Feature.Address.Model;

namespace RznMicro.Atlanta.Feature.User.Model
{
    public class UserEntity : Entity, IAggregateRoot
    {
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
        public bool? Active { get; set; }
        public GenderEnum Gender{ get; set; }

        //public string AvatarUrl { get; set; }
        //public string AvatarKeyName { get; set; }

        // EF Relations
        public UserEntity() { }
        public virtual IEnumerable<AddressEntity> Address { get; set; }

        /// <summary>
        /// Constructor for Insert
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="dateBirth"></param>
        public UserEntity(string fullName, DateTime dateBirth)
        {
            FullName = fullName;
            DateBirth = dateBirth;
            Active = true;
        }

        /// <summary>
        /// Constructor for Update
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="dateBirth"></param>
        /// <param name="active"></param>
        public UserEntity(string fullName, DateTime dateBirth, bool active)
        {
            FullName = fullName;
            DateBirth = dateBirth;
            Active = active;
        }

        public override void SetId(Guid id)
        {
            base.SetId(id);
        }
    }
}