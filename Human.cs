using FantasyPopulationSimulator.Console.Interfaces;
using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;

namespace FantasyPopulationSimulator.Console
{
    public class Human : IRace
    {
        public int StartOfFertility { get; } = 16 * DaysInYear;
        public int EndOfFertility { get; } = 50 * DaysInYear;
        public int PregnancyDurationInDays { get; } = 30 * 9;
        public IRace CreatesChildrenOfRace() => new Human();
        public long TimeBetweenPregnancies { get; set; } = 3 * DaysInYear;   
        public int DiesAtAge { get; set; } = 80 * DaysInYear; 
    }


}
