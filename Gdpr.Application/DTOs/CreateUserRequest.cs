namespace Gdpr.Application.DTOs;

public class CreateUserRequest
{
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
}