namespace RznMicro.Atlanta.Common;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    #region GetAll
    /// <summary>
    /// Get all data as tracking
    /// </summary>
    IQueryable<TEntity> GetAll();

    /// <summary>
    /// Get all data as no tracking
    /// </summary>
    IQueryable<TEntity> GetAllReadOnly();
    #endregion

    #region GetById
    /// <summary>
    /// Get data by ID as no async
    /// </summary>
    /// <param name="id">Int</param>
    TEntity GetById(int id);

    /// <summary>
    /// Get data by ID as no async
    /// </summary>
    /// <param name="id">Guid</param>
    TEntity GetById(Guid id);

    /// <summary>
    /// Get data by ID as async
    /// </summary>
    /// <param name="id">Guid</param>
    Task<TEntity> GetByIdAsync(Guid id);

    /// <summary>
    /// Get data by ID as async
    /// </summary>
    /// <param name="id">Int</param>
    Task<TEntity> GetByIdAsync(int id);

    /// <summary>
    /// Get data by ID as async
    /// </summary>
    /// <param name="id">Long</param>
    Task<TEntity> GetByIdAsync(long id);
    #endregion

    #region Add
    /// <summary>
    /// Add simple data
    /// </summary>
    /// <param name="entity">Model</param>
    void Add(TEntity entity);

    /// <summary>
    /// Add simple data as async
    /// </summary>
    /// <param name="entity">Model</param>
    Task AddAsync(TEntity entity);

    /// <summary>
    /// Add mass data range as async
    /// </summary>
    /// <param name="entities">List<Model></param>
    Task MassAddAsync(List<TEntity> entities);

    /// <summary>
    /// Add mass data range
    /// </summary>
    /// <param name="entities">List<Model></param>
    void MassAdd(List<TEntity> entities);
    #endregion

    #region Edit
    void Edit(TEntity entity, string propertyName);
    void Edit(TEntity entity, string[] propertiesName);
    #endregion

    #region Delete
    /// <summary>
    /// Delete simple data
    /// </summary>
    /// <param name="entity">Model</param>
    void Delete(TEntity entity);


    /// <summary>
    /// Delete mass data range
    /// </summary>
    /// <param name="entities">List<Model></param>
    void MassDelete(List<TEntity> entities);


    /// <summary>
    /// Delete mass data range
    /// </summary>
    /// <param name="entities">ICollection<Model></param>
    void MassDelete(ICollection<TEntity> entities);


    /// <summary>
    /// Delete mass data range
    /// </summary>
    /// <param name="entities">IQueryable<Model></param>
    void MassDelete(IQueryable<TEntity> entities);
    #endregion
}
