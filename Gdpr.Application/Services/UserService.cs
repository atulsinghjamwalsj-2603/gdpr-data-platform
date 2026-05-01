using Gdpr.Application.DTOs;
using Gdpr.Application.Interfaces;
using Gdpr.Domain.Entities;

namespace Gdpr.Application.Services;

public class UserService : IUserService
{
    public Guid CreateUser(CreateUserRequest request)
    {
        var user = new User(request.Email, request.FullName);

        // Later: save to database

        return user.Id;
    }
}