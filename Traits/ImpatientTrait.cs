using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class ImpatientTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Impatient;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
