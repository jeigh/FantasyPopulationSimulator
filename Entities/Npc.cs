using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console.Entities
{

    public class Npc 
    {
        private readonly Npc? _mother;
        private readonly Npc? _father;
        

        public IDictionary<TraitEnum, ITrait> Traits = new Dictionary<TraitEnum, ITrait>();

        public Npc(Npc mother, Npc? father)
        {

            _mother = mother;
            _father = father;

            Race = _mother.Race.CreatesChildrenOfRace();
            
            Culture = _mother.Culture;                  // todo: matrilineal or patrilineal culture?
            CurrentZone = _mother.CurrentZone;    // todo: matrilineal or patrilineal zone?
        }

        public Npc(IRace race, ICulture culture, IZone currentZone)
        {
            Race = race;
            Culture = culture;
            CurrentZone = currentZone;
        }

        public ICulture Culture { get; set; } = null;
        public IRace Race { get; private set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } // todo: make last name not nullable
        public Sex Sex { get; set; } = Sex.None;        
        public IZone? CurrentZone { get; set; }
        public long BirthDate { get; set; } = 0;
        public long LastPregnancyEnded { get; set; } = 0;
        public long LastImpregnatedOn { get; set; } = 0;
        public int ChildrenCount { get; set; } = 0;
        public bool IsDead { get; set; } = false;

        public bool IsPregnant() => LastImpregnatedOn > 0;
        
        public void GiveTrait(ITrait trait)
        {
            if (Traits.ContainsKey(trait.Trait)) return;
            Traits.Add(trait.Trait, trait);
        }

        public bool HasTrait(TraitEnum trait) => Traits.Any(t => t.Key == trait); 
        public long GetNpcCount() => 1;        
    }

}




