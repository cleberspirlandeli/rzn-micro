using RznMicro.Atlanta.Common;
using RznMicro.Atlanta.Database.Feature;

namespace RznMicro.Atlanta.Database.UnitOfWork.Base;

public abstract class GenericUnitOfWork : IGenericUnitOfWork
{
    protected readonly IServiceProvider _serviceProvider;
    protected readonly DefaultDataBaseContext _context;

    public GenericUnitOfWork(DefaultDataBaseContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Commit as no async
    /// </summary>
    public virtual void Commit()
    {
        _context.SaveChanges();
    }

    /// <summary>
    /// Commit as async
    /// </summary>
    public virtual async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Rollback
    /// </summary>
    public virtual void Rollback()
    {
        // if necessary add any information or track the information
    }
}
