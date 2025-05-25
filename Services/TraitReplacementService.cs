using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Services
{
    public class TraitReplacementService
    {
        private readonly NpcTraitService _npcs;
        public TraitReplacementService(NpcTraitService npcs)
        {
            _npcs = npcs;
        }

        public void ReplaceWandererWithSettler(Traveller traveller)
        {
            _npcs.RemoveTraitFromNpc(traveller!.TravellerNpc, TraitEnum.Wanderer);
            _npcs.AddTraitToNpc(traveller!.TravellerNpc, TraitEnum.Settler);
        }
    }
}
