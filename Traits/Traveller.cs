using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class Traveller
    {
        public Npc? TravellerNpc { get; set; }
        public IZone? Destination { get; set; }
        public long TravelStartDate { get; set; } = -1;
        public long TravelEndDate { get; set; } = -1;
    }

}
