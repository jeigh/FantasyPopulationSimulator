using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class VengefulTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Vengeful;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
