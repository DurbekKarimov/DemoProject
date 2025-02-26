using LearnProject.Data.IRepositories;
using LearnProject.Data.Repositories;
using LearnProject.Service.Interfaces;
using LearnProject.Service.Services;

namespace LearnProject.Api.Extensions;

public static class ServiceExtension
{
    public static void AddCustomService(this IServiceCollection services)
    {
        // Folder Name: Generic Reporitory
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Folder Name : USer
        services.AddScoped<IUserService, UserService>();
    }
}
