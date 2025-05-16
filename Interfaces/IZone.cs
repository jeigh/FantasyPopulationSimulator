
namespace FantasyPopulationSimulator.Console.Interfaces
{
    public interface IZone
    {
        string ZoneName { get; set; }

        void AddZoneConnection(IZone adjacentZone, string connectionName);

        List<IZone> GetTargetZoneConnections();
    }
}
