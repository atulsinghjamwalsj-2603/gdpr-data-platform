namespace Gdpr.Domain.Entities;

public class Consent
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public string Type { get; private set; } = null!;// e.g., "EmailMarketing", "Tracking"

    public bool IsGranted { get; private set; }

    public DateTime GrantedAt { get; private set; }

    public DateTime? WithdrawnAt { get; private set; }

    private Consent() { } // For ORM

    public Consent(Guid userId, string type)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Type = type;
        IsGranted = true;
        GrantedAt = DateTime.UtcNow;
    }

    public void Withdraw()
    {
        if (!IsGranted)
            throw new InvalidOperationException("Consent already withdrawn.");

        IsGranted = false;
        WithdrawnAt = DateTime.UtcNow;
    }
}