namespace FantasyPopulationSimulator.Console
{
    public class Human : IRace
    {
        public int StartOfFertility { get; } = 16 * Constants.DaysInYear;
        public int EndOfFertility { get; } = 50 * Constants.DaysInYear;
        public int PregnancyDurationInDays { get; } = 30 * 9;
        public IRace CreatesChildrenOfRace() => new Human();
        public long TimeBetweenPregnancies { get; set; } = 3 * Constants.DaysInYear;   
        public int DiesAtAge { get; set; } = 80 * Constants.DaysInYear; 
    }


}
