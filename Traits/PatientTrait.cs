using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class PatientTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Patient;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
