using RznMicro.Atlanta.Common;

namespace RznMicro.Atlanta.Feature.User.Model
{
    public class UserModel : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public DateTime Age { get; set; }
        public bool Active { get; set; }

        /// <summary>
        /// Constructor for Insert
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public UserModel(string name, DateTime age)
        {
            Name = name;
            Age = age;
            Active = true;
        }

        /// <summary>
        /// Constructor for Update
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="active"></param>
        public UserModel(string name, DateTime age, bool active)
        {
            Name = name;
            Age = age;
            Active = active;
        }

        public override void SetId(Guid id)
        {
            base.SetId(id);
        }
    }
}