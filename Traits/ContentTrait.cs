using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class ContentTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Content;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
