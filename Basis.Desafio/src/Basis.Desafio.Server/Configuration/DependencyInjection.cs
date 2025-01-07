using Basis.Desafio.Application.Assuntos.Services;
using Basis.Desafio.Application.Livros.Services;
using Basis.Desafio.Domain.Repositories;
using Basis.Desafio.Domain.Services;
using Basis.Desafio.Infra.MongoDb.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Basis.Desafio.Server.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection DeclareServices(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            services.AddSingleton(config)
                     //repositories
                     .AddScoped<ILivroRepository, LivroRepository>()
                     .AddScoped<IAutorRepository, AutorRepository>()
                     .AddScoped<IAssuntoRepository, AssuntoRepository>()
                     //services
                     .AddScoped<ILivroService, LivroService>()
                     .AddScoped<IAutorService, AutorService>()
                     .AddScoped<IAssuntoService, AssuntoService>()
                     .AddSingleton<IMapper, ServiceMapper>();

            return services;
        }
    }
}