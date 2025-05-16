namespace FantasyPopulationSimulator.Console.Services
{
    public class RandomNumberGenerator
    {
        private Random _random;
        public RandomNumberGenerator(int seed) => _random = new Random(seed);
        public int GenerateBetween(int rangeStart, int rangeEnd) => _random.Next(rangeStart, rangeEnd+1);

        public double GeneratePercentage() => _random.NextDouble();
    }
}
