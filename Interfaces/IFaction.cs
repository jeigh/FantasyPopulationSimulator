namespace FantasyPopulationSimulator.Console.Interfaces
{
    public interface IFaction
    {
        // rank every relevant trait from -1 (sin) to 1 (virtue)
        Dictionary<string, double> TraitDispositions { get; set; } 

    }
}