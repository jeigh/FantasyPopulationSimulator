using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class HonestTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Honest;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
