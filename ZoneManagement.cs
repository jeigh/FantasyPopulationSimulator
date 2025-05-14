using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console
{
    public class ZoneManagement
    {
        public List<IZone> Zones { get; set; } = new List<IZone>();

        public Zone CreateNewZone(string zoneName)
        {
            var created = new Zone { ZoneName = zoneName };
            Zones.Add(created);
            return created;
        }

        public void AddAdjacentZone(IZone zone, IZone adjacentZone, bool twoWayConnection)
        {
            zone.AddZoneConnection(adjacentZone, $"{zone.ZoneName}_to_{adjacentZone.ZoneName}");
            if (twoWayConnection)
                adjacentZone.AddZoneConnection(zone, $"{adjacentZone.ZoneName}_to_{zone.ZoneName}");
        }
    }
}
