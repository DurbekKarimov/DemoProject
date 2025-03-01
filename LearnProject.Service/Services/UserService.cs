using AutoMapper;
using LearnProject.Data.IRepositories;
using LearnProject.Domain.Entities;
using LearnProject.Service.DTOs;
using LearnProject.Service.Exceptions;
using LearnProject.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LearnProject.Service.Services;

public class UserService : IUserService
{
    #region
    private readonly IMapper mapper;
    private readonly IRepository<User> repository;
    public UserService(IMapper mapper, IRepository<User> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var user = await repository.SelectAll()
            .Where(u => u.Email == dto.Email)
            .FirstOrDefaultAsync();
        if (user is not null)
            throw new LearnProjectException(409, "User is already exists");
        var mapped = mapper.Map<User>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        await repository.InsertAsync(mapped);

        return mapper.Map<UserForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await repository.SelectAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
        if (user is null)
            throw new LearnProjectException(404, "User is not found");
        await repository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync()
    {
        var users = await repository.SelectAll()
            .AsNoTracking()
            .ToListAsync();
        return mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var user = await repository.SelectAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
        if (user is null)
            throw new LearnProjectException(404, "User is not found");

        return mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
    {
        var user = await repository.SelectAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
        if (user is null)
            throw new LearnProjectException(404, "User is not found");
        var mapped = mapper.Map(dto, user);
        mapped.UpdatedAt = DateTime.UtcNow;
        await repository.UpdateAsync(mapped);

        return mapper.Map<UserForResultDto>(mapped);
    }
    #endregion
}
