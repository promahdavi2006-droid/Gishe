
using Gishe.presentation.Domain.Entities.Users;
using Gishe.Presention.Application.DTOs.Users;
using Gishe.Presention.Application.Interfaces.Repositories;
using Gishe.Presention.Application.Interfaces.Services;

namespace Gishe.Presention.Application.Features.Users.Consumers;

public class ConsumerService : IConsumerService
{
    private readonly IConsumerRepository _consumerRepository;

    public ConsumerService(IConsumerRepository consumerRepository)
    {
        _consumerRepository = consumerRepository;
    }

    public async Task<ConsumerDto?> GetByIdAsync(Guid id)
    {
        var consumer = await _consumerRepository.GetByIdAsync(id);

        if (consumer == null)
            return null;

        return new ConsumerDto
        {
            Id = consumer.Id,
            Name = consumer.Name,
            FamilyName = consumer.FamilyName,
            Email = consumer.Email,
            PhoneNumber = consumer.PhoneNumber
        };
    }

    public async Task<List<ConsumerDto>> GetAllAsync()
    {
        var consumers = await _consumerRepository.GetAllAsync();

        return consumers.Select(consumer => new ConsumerDto
        {
            Id = consumer.Id,
            Name = consumer.Name,
            FamilyName = consumer.FamilyName,
            Email = consumer.Email,
            PhoneNumber = consumer.PhoneNumber
        }).ToList();
    }

    public async Task<ConsumerDto> CreateAsync(ConsumerDto dto)
    {
        var consumer = new Consumer(
            dto.Name,
            dto.FamilyName,
            dto.Email,
            dto.PhoneNumber,
            "",
             dto.DateOfBirth
        );

        await _consumerRepository.AddAsync(consumer);

        return new ConsumerDto
        {
            Id = consumer.Id,
            Name = consumer.Name,
            FamilyName = consumer.FamilyName,
            Email = consumer.Email,
            PhoneNumber = consumer.PhoneNumber
        };
    }

    public async Task<bool> UpdateAsync(Guid id, ConsumerDto dto)
    {
        var consumer = await _consumerRepository.GetByIdAsync(id);

        if (consumer == null)
            return false;

        consumer.UpdateProfile(
            dto.Name,
            dto.FamilyName,
            dto.Email,
            dto.PhoneNumber
        );

        _consumerRepository.Update(consumer);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var consumer = await _consumerRepository.GetByIdAsync(id);

        if (consumer == null)
            return false;

        _consumerRepository.Delete(consumer);

        return true;
    }
}

