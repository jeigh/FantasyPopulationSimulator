using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console.Cultures
{
    public class DarkElfCulture : ICulture
    {
        private readonly DefaultCulture _defaults;

        public DarkElfCulture(RandomNumberGenerator rand)
        {
            _defaults = new DefaultCulture(rand);
        }

        public Dictionary<string, double> TraitDispositions { get; set; } = new Dictionary<string, double>();

        public string GetRandomFemaleName()
        {
            return _defaults.GetRandomFemaleName();  // todo: think of a list for dark elf males
        }

        public string GetRandomMaleName()
        {
            return _defaults.GetRandomMaleName(); // todo: think of a list for dark elf males
        }
    }


}
