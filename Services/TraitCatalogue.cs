using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Traits;

namespace FantasyPopulationSimulator.Console.Services
{
    public class TraitCatalogue
    {
        private Dictionary<string, ITrait> Traits { get; set; } = new Dictionary<string, ITrait>();

        public TraitCatalogue(WandererTrait wandererTrait, SettlerTrait settlerTrait)
        {
            Traits.Add("Wanderer", wandererTrait);
            Traits.Add("Settler", settlerTrait);
        }



        public ITrait GetTraitByName(string name)
        {
            if (Traits.TryGetValue(name, out ITrait? value)) return value;
            throw new ApplicationException($"Trait {name} not found in catalogue.");
        }
    }
}
