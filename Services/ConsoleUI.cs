namespace FantasyPopulationSimulator.Console.Services
{
    public class ConsoleUI 
    {

        public void EmitSummary(WorldState _root, long currentYear) 
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


