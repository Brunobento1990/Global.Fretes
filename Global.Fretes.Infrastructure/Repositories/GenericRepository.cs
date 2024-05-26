using Global.Fretes.Domain.Interfaces;
using Global.Fretes.Infrastructure.Context;

namespace Global.Fretes.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _appDbContext;

    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddAsync(T entity)
    {
        await _appDbContext.AddAsync(entity);
    }

    public void DeleteAsync(T entity)
    {
        _appDbContext.Attach(entity);
        _appDbContext.Remove(entity);
    }

    public void EditAsync(T entity)
    {
        _appDbContext.Attach(entity);
        _appDbContext.Update(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }
}
