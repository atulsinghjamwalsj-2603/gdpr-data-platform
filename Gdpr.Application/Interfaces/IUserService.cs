using Gdpr.Application.DTOs;

namespace Gdpr.Application.Interfaces;

public interface IUserService
{
    Guid CreateUser(CreateUserRequest request);

    Task<PaginatedResponse<UserResponseDto>> GetPagedAsync(int pageNumber, int pageSize);

    Task UpdateAsync(Guid id, UpdateUserRequest request);
    
    Task DeleteAsync(Guid id);
}