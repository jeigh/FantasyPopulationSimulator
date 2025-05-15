using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Constants;

namespace FantasyPopulationSimulator.Console
{

    public class Npc : ITickable
    {
        private readonly NpcBehavior _behavior;
        private readonly Npc? _mother;
        private readonly Npc? _father;
        private readonly ChildPopulationTracker _tracker;

        private List<ITrait> Traits { get; set; } = new List<ITrait>();

        public Npc(Npc mother, Npc? father, NpcBehavior behavior, ChildPopulationTracker tracker)
        {
            _behavior = behavior;
            _tracker = tracker;

            _mother = mother;
            _father = father;

            Race = _mother.Race.CreatesChildrenOfRace();
            
            Culture = _mother.Culture;                  // todo: matrilineal or patrilineal culture?
            CurrentZone = _mother.CurrentZone;    // todo: matrilineal or patrilineal zone?
        }

        public Npc(IRace race, ICulture culture, IZone currentZone, NpcBehavior behavior, ChildPopulationTracker tracker)
        {
            _behavior = behavior;
            _tracker = tracker;

            Race = race;
            Culture = culture;
            CurrentZone = currentZone;
        }

        public ICulture Culture { get; set; } = null;
        public IRace Race { get; private set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } // todo: make last name not nullable
        public int AgeInDays { get; set; } = 0;
        public Sex Sex { get; set; } = Sex.None;        
        public IZone CurrentZone { get; private set; }
        public long BirthDate { get; set; } = 0;
        public long LastPregnancyEnded { get; set; } = 0;
        public long LastImpregnatedOn { get; set; } = 0;
        public bool IsPregnant() => LastImpregnatedOn > 0;
        public void GiveTrait(ITrait trait) => Traits.Add(trait);
        public bool HasTrait(ITrait trait) => Traits.Contains(trait);        
        public long GetNpcCount() => 1;        
        public string GetAssignedZoneName() => 
            string.Empty; // violation of liskov substitution principle
                            
        public void BlockUntilTickCompletes(long day) => 
            _behavior.BlockUntilTickCompletes(_tracker, this, day);

    }

}




