namespace FantasyPopulationSimulator.Console.Interfaces
{
    public interface ITicker
    {
        void Remove(ITickable tickable);
        void Add(ITickable tickable);
        long GetNpcCount();
    }
}
