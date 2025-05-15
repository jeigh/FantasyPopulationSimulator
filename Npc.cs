using FantasyPopulationSimulator.Console.Interfaces;
using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Traits;

namespace FantasyPopulationSimulator.Console
{
    public class Npc : ITickable
    {
        private readonly PopulationTracker _pop;
        private readonly ConsoleUI _ui;
        private readonly RandomNumberGenerator _rand;

        public Npc(PopulationTracker pop, Npc mother, Npc? father, ConsoleUI ui, RandomNumberGenerator rand)
        {
            _pop = pop;
            _ui = ui;
            _rand = rand;

            _mother = mother;
            _father = father;

            _race = _mother._race.CreatesChildrenOfRace();
            
            Culture = _mother.Culture;                  // todo: matrilineal or patrilineal culture?
            _currentZone = _mother.GetCurrentZone();    // todo: matrilineal or patrilineal zone?

        }

        public Npc(PopulationTracker pop, IRace race, ICulture culture, IZone currentZone, ConsoleUI ui, RandomNumberGenerator rand)
        {
            _pop = pop;
            _race = race;
            _rand = rand;
            Culture = culture;
            _currentZone = currentZone;
            _ui = ui;
        }

        private readonly IRace _race;

        private Npc? _mother { get; set; } = null;
        private Npc? _father { get; set; } = null;

        public ICulture Culture { get; set; } = null;

        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } // todo: make last name not nullable
        public int AgeInDays { get; set; } = 0;
        public Sex Sex { get; set; } = Sex.None;
        public int BirthDay()  => (int)(BirthDate % DaysInYear);
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

            if (BirthDay() == today % DaysInYear) _ui.NpcBirthday();
            if (CanGiveBirthToday(today)) GiveBirth(today);
            if (CanGetPregnant(today)) Impregnate(today);
            if (IsAdult(today))
            {
                if (ProbabilityOfGettingANewTraitAtDay(AgeInDays) >= _rand.GeneratePercentage())
                    GiveTrait(new WandererTrait());
            }

            AgeInDays++;
        }

        private List<ITrait> Traits { get; set; } = new List<ITrait>();

        private void GiveTrait(ITrait trait) => Traits.Add(trait);

        public bool HasTrait(ITrait trait) => Traits.Contains(trait);

        // todo: use calculus to return what the equasion should be when the cdf (or more accurately, integral of f(g)) goes from
        // f(g)=0 when g= (350*18) to f(g)=0.10 when g = (350*80) instead of just approximating a hard coded value
        //
        // using a hard coded value assumes an equal chance that someone will gain a trait throughout their life
        // but I believe people are more likely to get their traits sooner in life
        public double ProbabilityOfGettingANewTraitAtDay(int ageInDays) =>
             0.00001f;   //small probability of occurring each day
         

        private void Die()
        {
            _ui.NpcDeath();
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

        public IRace GetRaceOfChildren() => 
            _race.CreatesChildrenOfRace();  // todo: when two parents arent of the same race?

        public long GetNpcCount() => 1;

        public string GetAssignedZoneName() => string.Empty; // violation of liskov substitution principle

        public bool IsAdult(long today) =>
            AgeInDays >= _race.AdulthoodBeginsAt;

    }

}
