namespace FantasyPopulationSimulator.Console
{
    public interface IZone
    {
        string ZoneName { get; set; }
    }

    public class Zone : IZone
    {
        public string ZoneName { get; set; }
    }
}
