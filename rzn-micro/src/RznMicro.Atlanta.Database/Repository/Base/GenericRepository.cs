using Microsoft.EntityFrameworkCore;
using RznMicro.Atlanta.Common;
using System.Reflection;

namespace RznMicro.Atlanta.Database.Repository.Base;

public abstract class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
    where TEntity : Entity, new()
    where TContext : DbContext
{
    protected readonly TContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(TContext context)
    {
        _dbSet = context.Set<TEntity>();
        _context = context;
    }

    #region GetAll
    /// <summary>
    /// Get all data as tracking
    /// </summary>
    public IQueryable<TEntity> GetAll()
    {
        return _dbSet;
    }

    /// <summary>
    /// Get all data as no tracking
    /// </summary>
    public IQueryable<TEntity> GetAllReadOnly()
    {
        return _dbSet.AsNoTracking();
    }
    #endregion

    #region GetById
    /// <summary>
    /// Get data by ID as no async
    /// </summary>
    /// <param name="id">Int</param>
    public virtual TEntity GetById(int id)
    {
        return _dbSet.Find(id);
    }

    /// <summary>
    /// Get data by ID as no async
    /// </summary>
    /// <param name="id">Guid</param>
    public virtual TEntity GetById(Guid id)
    {
        return _dbSet.Find(id);
    }

    /// <summary>
    /// Get data by ID as async
    /// </summary>
    /// <param name="id">Guid</param>
    public virtual async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <summary>
    /// Get data by ID as async
    /// </summary>
    /// <param name="id">Int</param>
    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <summary>
    /// Get data by ID as async
    /// </summary>
    /// <param name="id">Long</param>
    public virtual async Task<TEntity> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }
    #endregion

    #region Add
    /// <summary>
    /// Add simple data
    /// </summary>
    /// <param name="entity">Model</param>
    public virtual void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    /// <summary>
    /// Add simple data as async
    /// </summary>
    /// <param name="entity">Model</param>
    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    /// <summary>
    /// Add mass data range as async
    /// </summary>
    /// <param name="entities">List<Model></param>
    public virtual async Task MassAddAsync(List<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    /// <summary>
    /// Add mass data range
    /// </summary>
    /// <param name="entities">List<Model></param>
    public virtual void MassAdd(List<TEntity> entities)
    {
        _dbSet.AddRange(entities);
    }
    #endregion

    #region Edit
    public void Edit(TEntity entity, string propertyName)
    {
        _context.Entry(entity).Property(propertyName).IsModified = true;
    }

    public void Edit(TEntity entity, string[] propertiesName)
    {
        if (propertiesName != null && propertiesName.Any())
        {
            foreach (var property in propertiesName)
                Edit(entity, property);
        }
    }
    
    public void Edit(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
            _context.Attach(entity);

        var modifiedProperties = _context.Entry(entity)
                .Properties
                .Where(p => p.IsModified)
                .Select(p => p.Metadata.Name)
                .ToList();

        foreach (PropertyInfo propertyInfo in typeof(TEntity).GetProperties())
        {
            if (modifiedProperties.Contains(propertyInfo.Name))
                _context.Entry(entity).Property(propertyInfo.Name).IsModified = true;
        }
    }

    public void Update(TEntity entity)
    {
        _context.Update(entity);
    }
    #endregion

    #region Delete
    /// <summary>
    /// Delete simple data
    /// </summary>
    /// <param name="entity">Model</param>
    public virtual void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    /// <summary>
    /// Delete mass data range
    /// </summary>
    /// <param name="entities">List<Model></param>
    public virtual void MassDelete(List<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    /// <summary>
    /// Delete mass data range
    /// </summary>
    /// <param name="entities">ICollection<Model></param>
    public virtual void MassDelete(ICollection<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    /// <summary>
    /// Delete mass data range
    /// </summary>
    /// <param name="entities">IQueryable<Model></param>
    public virtual void MassDelete(IQueryable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }
    #endregion

}
