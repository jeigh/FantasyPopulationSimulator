namespace FantasyPopulationSimulator.Console.Services
{
    public class ConsoleUI 
    {
        private readonly WorldService _worldService;
        private readonly WorldState _worldState;

        public ConsoleUI(WorldService worldService, WorldState worldState)
        {
            _worldService = worldService;
            _worldState = worldState;
        }

        public void EmitSummary(long currentYear) 
        {
            var totalNpcCount = _worldService.GetNpcCount(_worldState);
            System.Console.WriteLine($"Year: {currentYear}, Total Npc Count: {totalNpcCount}");
            foreach(var childPop in _worldState.GetAllTickables())
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


