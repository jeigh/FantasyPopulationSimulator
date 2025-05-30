using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Interfaces
{
    public interface ITrait
    {
        bool ProcessTickAndContinue(Npc npc);  // true if continue, false if NPC should not be processed anymore for this tick.
        
        TraitEnum Trait { get; }
    }

}
