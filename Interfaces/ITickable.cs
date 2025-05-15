namespace FantasyPopulationSimulator.Console.Interfaces
{
    public interface ITickable
    {
        void BlockUntilTickCompletes(ChildPopulationTracker pop, long day);
        string GetAssignedZoneName();
        long GetNpcCount();
    }
}
