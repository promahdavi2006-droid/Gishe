using System;
using System.Collections.Generic;
using System.Text;
using Gishe.presentation.Domain.Enums;

namespace Gishe.presentation.Domain.Users;

public class Provider : User
{
    private Provider()
    {
    }
    public Provider(
        string name,
        string familyName,
        string email,
        string businessName,
        string bankAccount,
        string phoneNumber,
        string passwordHash
       ) : base(name, familyName, email, phoneNumber, passwordHash)
    {
        BusinessName = businessName;
        BankAccount = bankAccount;
        VerificationStatus = VerificationStatus.Pending;
        CommissionRate = 0;

    }
    public string BusinessName { get; private set; }
    public string BankAccount { get; private set; }
    public VerificationStatus VerificationStatus { get; private set; }
    public decimal CommissionRate { get; private set; }
    protected override void InitiateId()
    {
        Id = Guid.NewGuid();
    }
    public void UpdateBusinessInformation(
        string businessName,
        string bankAccount)
    {
        BusinessName = businessName;
        BankAccount = bankAccount;
        SetUpdatedAt();
    }
    public void SetCommissionRate(decimal commissionRate)
    {
        if (commissionRate < 0)
            throw new ArgumentException("Commission rate cannot be negative.");
        CommissionRate = commissionRate;
        SetUpdatedAt();
    }
    public void Approve()
    {
        VerificationStatus = VerificationStatus.Approved;
        SetUpdatedAt();
    }
    public void Reject()
    {
        VerificationStatus = VerificationStatus.Rejected;
        SetUpdatedAt();
    }
}
