using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class TrustingTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Trusting;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
