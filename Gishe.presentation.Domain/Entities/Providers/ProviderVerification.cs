using Gishe.presentation.Domain.Base;
using Gishe.presentation.Domain.Enums;

namespace Gishe.presentation.Domain.Entities.Providers;

public class ProviderVerfication : BaseEntity<int>
{
    private ProviderVerfication()
    {

    }
    public ProviderVerfication(string documents)
    {
        InitiateId();
        Documents = documents;
        Status = VerificationStatus.Pending;
    }
    public int ProviderId { get; private set; }
    public string Documents { get; private set; }
    public VerificationStatus Status { get; private set; }
    public DateTime? ReviewedAt { get; private set; }
    protected override void InitiateId()
    {
        Id = Random.Shared.Next(1, int.MaxValue);
    }
    public void Approve()
    {
        Status = VerificationStatus.Pending;
        ReviewedAt = DateTime.UtcNow;
    }
    public void Reject()
    {
        Status = VerificationStatus.Rejected;
        ReviewedAt = DateTime.UtcNow;
    }

}
