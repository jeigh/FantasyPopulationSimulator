using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Services
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
