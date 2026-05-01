using Gdpr.Application.DTOs;

namespace Gdpr.Application.Interfaces;

public interface IUserService
{
    Guid CreateUser(CreateUserRequest request);
}