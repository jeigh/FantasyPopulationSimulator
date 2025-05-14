using System.Security.Cryptography;

namespace FantasyPopulationSimulator.Console.Interfaces
{

    public interface IRace
    {
        public int StartOfFertility { get; }
        public int EndOfFertility { get; }
        public int PregnancyDurationInDays { get; }
        long TimeBetweenPregnancies { get; set; }   //todo: make this based on a normal distribution instead of a fixed value
        int DiesAtAge { get; set; }                 // todo: make this based on a normal distribution instead of a fixed value

        IRace CreatesChildrenOfRace();
    }


}
