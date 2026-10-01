using Gishe.presentation.Domain.Entities.Users;
using Gishe.Presentation.Application.DTOs.Users;
using Gishe.Presentation.Application.Interfaces.Repositories;
using Gishe.Presentation.Application.Interfaces.Services;

namespace Gishe.Presentation.Application.Features.Users.Providers;

public class ProviderService : IProviderService
{
    private readonly IProviderRepository _providerRepository;

    public ProviderService(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public async Task<ProviderDto?> GetByIdAsync(Guid id)
    {
        var provider = await _providerRepository.GetByIdAsync(id);

        if (provider == null)
            return null;

        return new ProviderDto
        {
            Id = provider.Id,
            Name = provider.Name,
            FamilyName = provider.FamilyName,
            Email = provider.Email,
            PhoneNumber = provider.PhoneNumber,
            BusinessName = provider.BusinessName,
            BankAccount = provider.BankAccount,
            CommissionRate = provider.CommissionRate,
            VerificationStatus = (int)provider.VerificationStatus
        };
    }

    public async Task<List<ProviderDto>> GetAllAsync()
    {
        var providers = await _providerRepository.GetAllAsync();

        return providers.Select(provider => new ProviderDto
        {
            Id = provider.Id,
            Name = provider.Name,
            FamilyName = provider.FamilyName,
            Email = provider.Email,
            PhoneNumber = provider.PhoneNumber,
            BusinessName = provider.BusinessName,
            BankAccount = provider.BankAccount,
            CommissionRate = provider.CommissionRate,
            VerificationStatus = (int)provider.VerificationStatus
        }).ToList();
    }

    public async Task<ProviderDto> CreateAsync(ProviderDto dto)
    {
        var provider = new Provider(
            dto.Name,
            dto.FamilyName,
            dto.Email,
            dto.PhoneNumber,
            "",
            dto.BusinessName,
            dto.BankAccount
        );

        await _providerRepository.AddAsync(provider);

        return new ProviderDto
        {
            Id = provider.Id,
            Name = provider.Name,
            FamilyName = provider.FamilyName,
            Email = provider.Email,
            PhoneNumber = provider.PhoneNumber,
            BusinessName = provider.BusinessName,
            BankAccount = provider.BankAccount,
            CommissionRate = provider.CommissionRate,
            VerificationStatus = (int)provider.VerificationStatus
        };
    }

    public async Task<bool> UpdateAsync(Guid id, ProviderDto dto)
    {
        var provider = await _providerRepository.GetByIdAsync(id);

        if (provider == null)
            return false;

        provider.UpdateProfile(
            dto.Name,
            dto.FamilyName,
            dto.Email,
            dto.PhoneNumber
        );

        provider.UpdateBusinessInformation(
            dto.BusinessName,
            dto.BankAccount
        );

        await _providerRepository.UpdateAsync(provider);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var provider = await _providerRepository.GetByIdAsync(id);

        if (provider == null)
            return false;

        await _providerRepository.DeleteAsync(provider);

        return true;
    }
}
