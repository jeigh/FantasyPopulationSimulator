using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class CynicalTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Cynical;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
