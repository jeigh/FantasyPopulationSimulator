using FantasyPopulationSimulator.Console.Interfaces;
using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;

namespace FantasyPopulationSimulator.Console.Races
{
    public class DarkElf : IRace
    {
        public int StartOfFertility { get; } = 50 * DaysInYear;
        public int EndOfFertility { get; } = 225 * DaysInYear;
        public int PregnancyDurationInDays { get; } = 30 * 9;
        public int AdulthoodBeginsAt { get; set; } = 50 * DaysInYear;
        public IRace CreatesChildrenOfRace() => new DarkElf();
        public long TimeBetweenPregnancies { get; set; } = 3 * DaysInYear;
        public int DiesAtAge { get; set; } = 300 * DaysInYear;
        public Dictionary<string, double> TraitDispositions { get ; set ; }
    }


}
