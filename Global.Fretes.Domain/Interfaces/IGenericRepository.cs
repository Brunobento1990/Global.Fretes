namespace Global.Fretes.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task AddAsync(T entity);
    void EditAsync(T entity);
    void DeleteAsync(T entity);
    Task SaveChangesAsync();
}
