using Gdpr.Application.DTOs;
using Gdpr.Application.Interfaces;
using Gdpr.Domain.Entities;

namespace Gdpr.Application.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public Guid CreateUser(CreateUserRequest request)
    {
        var user = new User(request.Email, request.FullName);

        _repository.Add(user);
        _repository.SaveChangesAsync().Wait();

        return user.Id;
    }

    public async Task<PaginatedResponse<UserResponseDto>> GetPagedAsync(int pageNumber, int pageSize)
{
    var (users, total) = await _repository.GetPagedAsync(pageNumber, pageSize);

    var userDtos = users.Select(u => new UserResponseDto
    {
        UserId = u.Id,
        Email = u.Email.Value,
        FullName = u.FullName,
        CreatedAt = u.CreatedAt
    });

    return new PaginatedResponse<UserResponseDto>
    {
        Items = userDtos,
        PageNumber = pageNumber,
        PageSize = pageSize,
        TotalRecords = total
    };
}

   public async Task UpdateAsync(Guid id, UpdateUserRequest request)
{
    var user = await _repository.GetByIdAsync(id);

    if (user == null || user.IsDeleted)
        throw new Exception("User not found");

    user.UpdateEmail(request.Email);

    await _repository.SaveChangesAsync();
}

public async Task DeleteAsync(Guid id)
{
    var user = await _repository.GetByIdAsync(id);

    if (user == null || user.IsDeleted)
        throw new Exception("User not found");

    user.MarkAsDeleted();

    await _repository.SaveChangesAsync();
}
}