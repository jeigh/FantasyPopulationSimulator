namespace FantasyPopulationSimulator.Console
{
    public interface ITickable
    {
        void BlockUntilTickCompletes(long day);
        string GetAssignedZoneName();
        long GetNpcCount();
    }
}
