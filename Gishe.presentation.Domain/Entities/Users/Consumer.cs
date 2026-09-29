namespace Gishe.presentation.Domain.Entities.Users;

public class Consumer : User
{

    private Consumer()
    {

    }
    public Consumer(
        string name,
        string familyName,
        string email,
        string phoneNumber,
        string passwordHash,
        DateTime dateOfBirth
       ) : base(name, familyName, email, phoneNumber, passwordHash)

    {

        DateOfBirth = dateOfBirth;
    }
    public DateTime DateOfBirth { get; private set; }

    protected override void InitiateId()
    {
        Id = Guid.NewGuid();
    }
}
