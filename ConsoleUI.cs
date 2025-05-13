

namespace FantasyPopulationSimulator.Console
{

// to be used in a future commit
    public class ZoneTracker
    {

        public void TravelTo(Npc npc, Zone from)
        {
            //todo
        }

        public List<Zone> GetAdjacentZones(Zone forZone)
        {
            var returnable = new List<Zone>();

            //todo

            return returnable;
        }
    }

    public class ConsoleUI 
    {

        public void EmitSummary(RootPopulationTracker _root, long currentYear) 
        {
            var totalNpcCount = _root.GetNpcCount();
            System.Console.WriteLine($"Year: {currentYear}, Total Npc Count: {totalNpcCount}");
            foreach(var childPop in _root.GetChildren())
            {
                var zoneNpcCount = childPop.GetNpcCount();
                System.Console.WriteLine($"Zone: {childPop.GetAssignedZoneName()}, Npc Count: {zoneNpcCount}");
            }
        }

        public void Clear() => System.Console.Clear();

        public void DeclareYear(int currentYear, long npcCount) => System.Console.WriteLine($"Year: {currentYear}, NpcCount: {npcCount}");

        public void NpcBirth(string firstName1, string firstName2)
        {
            return;
        }

        internal void NpcBirthday()
        {
            return;
        }

        internal void NpcDeath()
        {
            return;
        }
    }
}


