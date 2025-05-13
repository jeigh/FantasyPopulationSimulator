namespace FantasyPopulationSimulator.Console
{
    public interface ITickable
    {
        void BlockUntilTickCompletes(long day);
        long GetNpcCount();
    }
}
