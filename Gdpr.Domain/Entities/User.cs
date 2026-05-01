using Gdpr.Domain.ValueObjects;
namespace Gdpr.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }

    public Email Email { get; private set; }

    public string FullName { get; private set; } = null!;

    public bool IsDeleted { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private User() { } // For ORM later

    public User(string email, string fullName)
    {
        Id = Guid.NewGuid();
        Email = Email.Create(email);
        FullName = fullName;
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    public void MarkAsDeleted()
    {
        IsDeleted = true;
    }
}