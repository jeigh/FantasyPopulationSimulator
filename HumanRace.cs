namespace FantasyPopulationSimulator.Console
{
    internal partial class Program
    {
        public class Human : IRace
        {
            public int StartOfFertility { get; } = 16 * DaysInYear;
            public int EndOfFertility { get; } = 50 * DaysInYear;
            public int PregnancyDurationInDays { get; } = 30*9;
            public IRace CreatesChildrenOfRace() => new Human();
        }

        public interface IRace
        {
            public int StartOfFertility { get; }
            public int EndOfFertility { get; }
            public int PregnancyDurationInDays { get; }

            IRace CreatesChildrenOfRace();
        }


    }
}
