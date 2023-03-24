using Homework.Data;
using Homework.Data.Repository;
using Homework.Data.UnitOfWork;

namespace Homework_1.Extension;

public static class StartUpExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        // uow
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // repos
        services.AddScoped<IGenericRepository<Staff>,GenericRepository<Staff>>();
        

       
    }
}
