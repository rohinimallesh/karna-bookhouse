using KarnaBookHouse.API.Models;

namespace KarnaBookHouse.API.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();

    Task<Book?> GetByIdAsync(int id);

    Task AddAsync(Book book);

    Task UpdateAsync(Book book);

    Task DeleteAsync(Book book);
}