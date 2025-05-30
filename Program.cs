using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Traits;
using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Races;
using FantasyPopulationSimulator.Console.Cultures;

namespace FantasyPopulationSimulator.Console.Services
{

    internal partial class Program
    {
        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddSingleton(_ => new RandomNumberGenerator(12));
            services.AddSingleton<WorldState>();
            services.AddSingleton<NpcBehavior>();
            services.AddSingleton<TraitReplacementService>();
            services.AddSingleton<TravelService>();
            services.AddSingleton<WorldService>();
            services.AddSingleton<DisplayService>();
            services.AddSingleton<ZoneManagement>();
            services.AddSingleton<InitialSetupHelper>();
            services.AddSingleton<PopulationService>();
            services.AddSingleton<NpcTraitService>();
            // traits
            services.AddSingleton<WandererTrait>();
            services.AddSingleton<SettlerTrait>();
            services.AddSingleton<BraveTrait>();
            services.AddSingleton<CravenTrait>();
            services.AddSingleton<CalmTrait>();
            services.AddSingleton<WrathfulTrait>();
            services.AddSingleton<ChasteTrait>();
            services.AddSingleton<LustfulTrait>();
            services.AddSingleton<ContentTrait>();
            services.AddSingleton<AmbitiousTrait>();
            services.AddSingleton<DiligentTrait>();
            services.AddSingleton<LazyTrait>();
            services.AddSingleton<ForgivingTrait>();
            services.AddSingleton<VengefulTrait>();
            services.AddSingleton<GenerousTrait>();
            services.AddSingleton<GreedyTrait>();
            services.AddSingleton<GregariousTrait>();
            services.AddSingleton<ShyTrait>();
            services.AddSingleton<HonestTrait>();
            services.AddSingleton<DeceitfulTrait>();
            services.AddSingleton<HumbleTrait>();
            services.AddSingleton<ArrogantTrait>();
            services.AddSingleton<JustTrait>();
            services.AddSingleton<ArbitraryTrait>();
            services.AddSingleton<PatientTrait>();
            services.AddSingleton<ImpatientTrait>();
            services.AddSingleton<TemperantTrait>();
            services.AddSingleton<GluttonousTrait>();
            services.AddSingleton<TrustingTrait>();
            services.AddSingleton<ParanoidTrait>();
            services.AddSingleton<ZealousTrait>();
            services.AddSingleton<CynicalTrait>();
            services.AddSingleton<CompassionateTrait>();
            services.AddSingleton<SadisticTrait>();
            services.AddSingleton<RacialAgonismTrait>();
            services.AddSingleton<RacialAntagonismTrait>();
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
            var rand = host.Services.GetRequiredService<RandomNumberGenerator>();

            Zone edenZone = setup.CreateStartingZoneForEden(zones, "Eden", new Human(), new DefaultCulture(rand), string.Empty);
            Zone darkElfEden = setup.CreateStartingZoneForEden(zones, "Dark Elf Eden", new DarkElf(), new DarkElfCulture(rand), "DE_");

            

            setup.SetupEverquestThemedZones(edenZone, darkElfEden);

            worldState.CurrentDate = 0;
            while (true)
            {
                if (worldState.CurrentDate % DaysInYear == 0)
                {
                    int currentYear = (int)(worldState.CurrentDate / DaysInYear);
                    ui.Clear();

                    if (worldState.CurrentDate % DaysInYear == 0) ui.EmitSummary(currentYear);
                }

                worldService.BlockUntilTickCompletes(worldState);
                
                worldState.CurrentDate = worldState.CurrentDate + 1;
            }
        }
    }
}
