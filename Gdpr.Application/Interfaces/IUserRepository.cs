using Gdpr.Domain.Entities;

namespace Gdpr.Application.Interfaces;

public interface IUserRepository
{
    void Add(User user);
    Task<(IEnumerable<User>, int)> GetPagedAsync(int pageNumber, int pageSize);
    Task<User?> GetByIdAsync(Guid id);
    Task SaveChangesAsync();
}