namespace RznMicro.Atlanta.Feature.User.Model
{
    public class UserModel : Entity
    {
        public string Name { get; set; }
        public DateTime Age { get; set; }
        public bool Active { get; set; }

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