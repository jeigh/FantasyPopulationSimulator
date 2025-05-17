using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console
{
    public class TraitReplacementService
    {
        private readonly NpcBehavior _npcs;
        public TraitReplacementService(NpcBehavior npcs)
        {
            _npcs = npcs;
        }

        public void ReplaceWandererWithSettler(Traveller traveller)
        {
            _npcs.RemoveTraitFromNpc(traveller!.TravellerNpc, "Wanderer");
            _npcs.AddTraitToNpc(traveller!.TravellerNpc, "Settler");
        }
    }
}
