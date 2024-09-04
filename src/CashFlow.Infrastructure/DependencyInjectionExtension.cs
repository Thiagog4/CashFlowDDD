using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = "";
        var version = new Version(9, 0, 1);
        var serverVersion = new MySqlServerVersion(version);
        //optionsBuilder.UseMySql(connectionString, serverVersion);
        services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}