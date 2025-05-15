using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Cultures
{
    public class DarkElfCulture : ICulture
    {
        private readonly DefaultCulture _defaults;

        public DarkElfCulture(RandomNumberGenerator rand)
        {
            _defaults = new DefaultCulture(rand);
        }

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
