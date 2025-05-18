using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class TemperantTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Temperant;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
