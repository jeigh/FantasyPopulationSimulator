namespace FantasyPopulationSimulator.Console.Interfaces
{
    public interface ITickable
    {
        void BlockUntilTickCompletes(IChildPopulationTracker pop, long day);
        string GetAssignedZoneName();
        long GetNpcCount();
    }
}
