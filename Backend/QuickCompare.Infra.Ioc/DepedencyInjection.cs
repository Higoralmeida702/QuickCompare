using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickCompare.Application.Interfaces;
using QuickCompare.Application.Services;
using QuickCompare.Domain.Interfaces;
using QuickCompare.Infra.Data.Data;
using QuickCompare.Infra.Data.Repository;
using QuickCompare.Infra.Data.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
            ));

        services.AddScoped<ICelularService, CelularService>();
        services.AddScoped<ICelularRepository, CelularRepository>();
        services.AddScoped<INotebookService, NotebookService>();
        services.AddScoped<INotebookRepository, NotebookRepository>();
        services.AddScoped<ICompararCelulares, CompararCelularService>();
        services.AddScoped<CompararCelularesUseCase>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }
}
