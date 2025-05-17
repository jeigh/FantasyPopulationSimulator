using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Traits;
using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FantasyPopulationSimulator.Console.Services
{

    internal partial class Program
    {
        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddSingleton<RandomNumberGenerator>(_ => new RandomNumberGenerator(12));
            services.AddSingleton<WorldState>();
            services.AddSingleton<ZoneRetrievalService>();
            services.AddSingleton<MovementService>();
            services.AddSingleton<WandererTrait>();
            services.AddSingleton<SettlerTrait>();
            services.AddSingleton<TraitCatalogue>();
            services.AddSingleton<NpcBehavior>();
            services.AddSingleton<TraitReplacementService>();
            services.AddSingleton<TravelService>();
            services.AddSingleton<WorldService>();
            services.AddSingleton<DisplayService>();
            services.AddSingleton<ZoneManagement>();
            services.AddSingleton<TrackerFactory>();
            services.AddSingleton<InitialSetupHelper>();
        }

        static void Main(string[] args)
        {
            var host = Host
                .CreateDefaultBuilder(args)
                .ConfigureServices(InjectDependencies)
                .Build();

            var setup = host.Services.GetRequiredService<InitialSetupHelper>();
            var ui = host.Services.GetRequiredService<DisplayService>();
            var worldService = host.Services.GetRequiredService<WorldService>();
            var worldState = host.Services.GetRequiredService<WorldState>();
            var zones = host.Services.GetRequiredService<ZoneManagement>();

            Zone edenZone = setup.CreateStartingZoneForEden(zones, "Eden");
            Zone darkElfEden = setup.CreateStartingZoneForEden(zones, "Dark Elf Eden");

            setup.SetupEverquestThemedZones(edenZone, darkElfEden);

            long day = 0;
            while (true)
            {
                if (day % DaysInYear == 0)
                {
                    int currentYear = (int)(day / DaysInYear);
                    ui.Clear();
                    //ui.DeclareYear(currentYear, root.GetNpcCount());

                    if (day % DaysInYear == 0) ui.EmitSummary(currentYear);
                }

                worldService.BlockUntilTickCompletes(worldState, day);

                day++;
            }
        }
    }
}
