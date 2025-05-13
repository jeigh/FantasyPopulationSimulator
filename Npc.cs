

using static FantasyPopulationSimulator.Console.Program;

namespace FantasyPopulationSimulator.Console
{
    public class Npc : ITickable
    {
        private readonly PopulationTracker _pop;

        public Npc(PopulationTracker pop, Npc mother, Npc? father)
        {
            _pop = pop;

            _mother = mother;
            _father = father;

            _race = _mother._race.CreatesChildrenOfRace();
            
            Culture = _mother.Culture;   // todo: matrilineal or patrilineal culture?
            _currentZone = _mother.GetCurrentZone(); // todo: matrilineal or patrilineal zone?

        }

        public Npc(PopulationTracker pop, IRace race, ICulture culture, IZone currentZone)
        {
            _pop = pop;
            _race = race;
            Culture = culture;
            _currentZone = currentZone;

        }

        private readonly IRace _race;

        private Npc? _mother { get; set; } = null;
        private Npc? _father { get; set; } = null;

        public ICulture Culture { get; set; } = null;

        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } // todo: make last name not nullable
        public int AgeInDays { get; set; } = 0;
        public Sex Sex { get; set; } = Sex.None;
        public int BirthDay()  => (int)(BirthDate % Constants.DaysInYear);
        private IZone _currentZone;
        public IZone GetCurrentZone() => _currentZone;

        public long BirthDate { get; set; } = 0;

        private long _lastPregnancyEnded { get; set; } = 0;
        private long _lastImpregnatedOn { get; set; } = 0;

        public bool IsPregnant() => _lastImpregnatedOn > 0;
        public void Impregnate(long currentDate) => _lastImpregnatedOn = currentDate;  //todo: expand this feature so as to allow twins?
        public bool IsFertile()
        {
            return
                AgeInDays >= _race.StartOfFertility &&
                AgeInDays < _race.EndOfFertility;
        }

        public void ResetPregnancy(long today)
        {
            _lastPregnancyEnded = today; //todo: make this a long
            _lastImpregnatedOn = 0;
        }


        public void BlockUntilTickCompletes(long today)
        {
            if (TimeToDie(today))
            {
                Die();
                return;
            }

            //if (BirthDay() == today % Constants.DaysInYear) System.Console.WriteLine($"Happy Birthday {FirstName}!");
            if (CanGiveBirthToday(today)) GiveBirth(today);
            if (CanGetPregnant(today)) Impregnate(today);

            AgeInDays++;
        }

        private void Die()
        {
            //System.Console.WriteLine($"{FirstName} {LastName} has died at age {AgeInDays}");
            _pop.Remove(this);
        }

        private bool TimeToDie(long today) => AgeInDays >= _race.DiesAtAge;

        private bool CanGiveBirthToday(long today) => 
            IsPregnant() && today >= _lastImpregnatedOn + _race.PregnancyDurationInDays;

        private void GiveBirth(long day)
        {
            ResetPregnancy(day);
            
            _pop.GenerateNewNpc(this, null, day); //todo: determine who the father is?
        }

        private bool CanGetPregnant(long today)   // todo: verify that a mate is nearby?
        {
            return (Sex == Sex.Female &&
                IsFertile() && 
                !IsPregnant() &&
                _lastPregnancyEnded + _race.TimeBetweenPregnancies <= today);
        }

        public IRace GetRaceOfChildren() => _race.CreatesChildrenOfRace();  // todo: when two parents arent of the same race?

        public long GetNpcCount() => 1;
    }

}
