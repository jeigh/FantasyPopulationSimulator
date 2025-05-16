using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Entities
{

    public class Zone : IZone
    {
        public string ZoneName { get; set; } = string.Empty;
        private Dictionary<string, IZone> AdjacentZones { get; set; } = new Dictionary<string, IZone>();

        public void AddZoneConnection(IZone adjacentZone, string connectionName) => 
            AdjacentZones.Add(connectionName, adjacentZone);

        public List<IZone> GetTargetZoneConnections() =>
            AdjacentZones.Values.ToList();
    }
}
