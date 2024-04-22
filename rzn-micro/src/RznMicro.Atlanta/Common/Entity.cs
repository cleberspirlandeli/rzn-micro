namespace RznMicro.Atlanta.Common;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public virtual void SetId(Guid id)
    {
        Id = id;
    }
}
