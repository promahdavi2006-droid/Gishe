namespace Gishe.Presentation.Application.DTOs.Users;

public class ConsumerDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string FamilyName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
}
