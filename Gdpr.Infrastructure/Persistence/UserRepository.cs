using Gdpr.Application.Interfaces;
using Gdpr.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gdpr.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
    }

    public async Task<(IEnumerable<User>, int)> GetPagedAsync(int pageNumber, int pageSize)
    {
    var query = _context.Users.AsQueryable();

    var totalRecords = await query.CountAsync();

    var users = await query
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return (users, totalRecords);
   }
   public async Task<User?> GetByIdAsync(Guid id)
   {
        return await _context.Users
           .FirstOrDefaultAsync(u => u.Id == id);
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}