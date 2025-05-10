

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
            _race = _mother._race.CreatesChildrenOfRace();
            _father = father;
        }

        public Npc(PopulationTracker pop, IRace race)
        {
            _pop = pop;
            _race = race;
        }

        private readonly IRace _race;

        private Npc? _mother { get; set; } = null;
        private Npc? _father { get; set; } = null;


        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } // todo: make last name not nullable
        public int AgeInDays { get; set; } = 0;
        public Sex Sex { get; set; } = Sex.None;
        public int BirthDay()  => (int)(BirthDate % Constants.DaysInYear);
        
        
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


        public void Tick(long today)
        {
            if (AgeInDays >= _race.DiesAtAge)
            {
                System.Console.WriteLine($"{FirstName} {LastName} has died at age {AgeInDays}");
                _pop.RemoveNpc(this);
                return;
            }

            if (BirthDay() == today % Constants.DaysInYear)
                System.Console.WriteLine($"Happy Birthday {FirstName}!");


            bool readyToGiveBirth = CanGiveBirthToday(today);
            if (readyToGiveBirth) GiveBirth(today);

            if (CanGetPregnant(today)) Impregnate(today);

            AgeInDays++;
        }

        private bool CanGiveBirthToday(long today) => 
            IsPregnant() && today >= _lastImpregnatedOn + _race.PregnancyDurationInDays;

        private void GiveBirth(long day)
        {
            ResetPregnancy(day);
            System.Console.WriteLine($"{FirstName} {LastName} Had a baby!");
            _pop.GenerateNewNpc(this, null, day); //todo: how do we determine who the father is?
        }

        private bool CanGetPregnant(long today)   // todo: verify that a mate is nearby?
        {
            return (Sex == Sex.Female &&
                IsFertile() && 
                !IsPregnant() &&
                _lastPregnancyEnded + _race.TimeBetweenPregnancies <= today);
        }

        public IRace GetRaceOfChildren() => _race.CreatesChildrenOfRace();  // todo: when two parents arent of the same race?
    }

}
