using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class GregariousTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Gregarious;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
