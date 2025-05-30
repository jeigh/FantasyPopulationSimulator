using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class CompassionateTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Compassionate;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
