using Gishe.presentation.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gishe.presentation.Domain.Entities.Users;

public abstract class User : BaseEntity<Guid>
{
    protected User()
    {
        Id = Guid.NewGuid();
    }
    protected User(
        string name,
        string familyName,
        string email,
        string phoneNumber,
        string passwordHash)
    {
        Id = Guid.NewGuid();
        Name = name;
        FamilyName = familyName;
        Email = email;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
        IsActive = true;
    }
    public string Name { get; private set; }
    public string FamilyName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string PasswordHash { get; private set; }
    public bool IsActive { get; private set; }
    public void UpdateProfile(
        string name,
        string familyName,
        string email,
        string phoneNumber)
    {
        Name = name;
        FamilyName = familyName;
        Email = email;
        PhoneNumber = phoneNumber;
        SetUpdatedAt();
    }
    public void ChangePassword(string passwordHash)
    {
        PasswordHash = passwordHash;
        SetUpdatedAt();
    }
    public void Deactivate()
    {
        IsActive = false;
        SetUpdatedAt();
    }
    public void Avtivate()
    {
        IsActive = true;
        SetUpdatedAt();
    }
    protected void SetUpdatedAt()
    {
        UpdatedAt = DateTime.Now;
    }

}
