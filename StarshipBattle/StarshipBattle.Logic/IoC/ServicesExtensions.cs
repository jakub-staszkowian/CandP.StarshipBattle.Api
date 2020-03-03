using Microsoft.Extensions.DependencyInjection;
using StarshipBattle.Data.EntityFramework.IoC;
using StarshipBattle.Logic.Services;
using StarshipBattle.Logic.Services.Interfaces;
using StarshipBattle.Logic.Validation.Interfaces;
using System.Linq;

namespace StarshipBattle.Logic.IoC
{
    public static class ServicesExtensions
    {
        public static void RegisterLogicServices(this IServiceCollection services)
        {
            services.RegisterEntityFrameworkDataLayer();
            services.AddScoped<IStarshipReadService, StarshipReadService>();
            services.AddScoped<IStarshipWriteService, StarshipWriteService>();
            services.RegisterValidators();
        }

        private static void RegisterValidators(this IServiceCollection services)
        {
            var validatorImplementations = typeof(IValidator<>).Assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsAssignableFrom(typeof(IValidator<>)))
                .ToList();

            foreach (var validator in validatorImplementations)
            {
                var interfaces = validator.GetInterfaces();

                foreach (var validatorInterface in interfaces)
                {
                    services.AddScoped(validatorInterface, validator);
                }
            }
        }
    }
}
