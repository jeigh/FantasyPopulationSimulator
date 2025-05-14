namespace FantasyPopulationSimulator.Console.Interfaces
{
    public interface ITickable
    {
        void BlockUntilTickCompletes(long day);
        string GetAssignedZoneName();
        long GetNpcCount();
    }
}
