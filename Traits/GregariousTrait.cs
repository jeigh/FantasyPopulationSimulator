using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class GregariousTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Gregarious;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
