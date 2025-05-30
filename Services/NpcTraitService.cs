using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Services
{
    public class NpcTraitService
    {
        private readonly WorldState _worldState;

        public NpcTraitService(WorldState worldState)
        {
            _worldState = worldState;
        }

        public void RemoveTraitFromNpc(Npc npc, TraitEnum trait)
        {
            npc.Traits.Remove(trait);
        }

        public void AddTraitToNpc(Npc npc, TraitEnum traitEnum)
        {
            if (npc.Traits.ContainsKey(traitEnum)) return;

            ITrait trait = _worldState.GetTraitByEnum(traitEnum);
            if (trait == null) return;

            npc.Traits.Add(traitEnum, trait);
        }
    }

}




