using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Interfaces
{
    public interface ITrait
    {
        bool ProcessTickAndContinue(Npc npc, long today);  // true if continue, false if NPC should not be processed anymore for this tick.
        static string Name { get; }
    }

}
