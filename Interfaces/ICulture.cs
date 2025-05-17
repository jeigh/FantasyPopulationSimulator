namespace FantasyPopulationSimulator.Console.Interfaces
{
    public interface ICulture : IFaction
    {
        string GetRandomFemaleName();
        string GetRandomMaleName();
    }
}