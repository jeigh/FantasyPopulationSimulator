
namespace FantasyPopulationSimulator.Console
{
    internal partial class Program
    {
        public class Npc : ITickable
        {
            private readonly PopulationTracker _pop;

            public Npc(PopulationTracker pop, IRace race)
            {
                _pop = pop;
                _race = race;
            }

            private readonly IRace _race;

            public Npc? Mother { get; set; } = null;
            public Npc? Father { get; set; } = null;
            

            public string FirstName { get; set; } = string.Empty;
            public string? LastName { get; set; } // todo: make last name not nullable
            public int AgeInDays { get; set; } = 0;
            public Sex Sex { get; set; } = Sex.None;
            public int BirthDay { get; set; } = 0;
            public long PregnancyDate { get; set; } = 0;
            public bool IsPregnant() => PregnancyDate > 0;
            public void Impregnate(long currentDate) => PregnancyDate = currentDate;
            public bool IsFertile() => AgeInDays >= _race.StartOfFertility;
            public void ResetPregnancy() => PregnancyDate = 0; 

            
            public void Tick(long day)
            {
                if (BirthDay == day % DaysInYear)
                    System.Console.WriteLine($"Happy Birthday {FirstName}!");


                if (IsPregnant() && day >= PregnancyDate + _race.PregnancyDurationInDays)
                {
                    ResetPregnancy();
                    System.Console.WriteLine($"{FirstName} {LastName} Had a baby!");
                    _pop.GenerateNewNpc(this, null, day); //todo: how do we determine who the father is?
                }

                if (Sex == Sex.Female && IsFertile() && !IsPregnant()) Impregnate(day);

                AgeInDays++;
            }

            public IRace GetRaceOfChildren() => _race.CreatesChildrenOfRace();  // todo: when two parents arent of the same race?
        }


    }
}
