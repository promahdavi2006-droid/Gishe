using System;
using System.Collections.Generic;
using System.Text;

namespace Gishe.presentation.Domain.Entities.Users;

public class SuperAdmin : User
{
    private SuperAdmin()
    {

    }
    public SuperAdmin(
        string name,
        string familyName,
        string email,
        string phoneNumber,
        string passwordHash) : base(
            name,
            familyName,
            email,
            phoneNumber,
            passwordHash)
    {

    }
    protected override void InitiateId()
    {
        Id = Guid.NewGuid();
    }

}

