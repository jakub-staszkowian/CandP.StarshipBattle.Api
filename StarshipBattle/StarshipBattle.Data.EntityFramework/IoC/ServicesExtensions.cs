using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace StarshipBattle.Data.EntityFramework.IoC
{
    public static class ServicesExtensions
    {
        public static void RegisterEntityFrameworkDataLayer(this IServiceCollection services)
        {
            services.AddDbContext<StarshipBattleContext>(options => options.UseSqlServer("Data Source=.;Initial Catalog=StarshipsBattle.DEV;Integrated Security=True"));
            services.AddScoped<IRepository, StarshipBattleContext>();
        }
    }
}
