namespace RznMicro.Atlanta.Common;

public interface IGenericUnitOfWork
{
    /// <summary>
    /// Commit as no async
    /// </summary>
    void Commit();

    /// <summary>
    /// Commit as async
    /// </summary>
    Task CommitAsync();

    /// <summary>
    /// Rollback
    /// </summary>
    void Rollback();
}
