using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Traits;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console
{

    //public interface IChildPopulationTracker
    //{
    //    void Remove(ITickable npc);
    //    void GenerateNewNpc(Npc mother, Npc? father, long day);

    //}

    public class NpcBehavior
    {
        private readonly ConsoleUI _ui;
        private readonly RandomNumberGenerator _rand;

        public NpcBehavior(ConsoleUI ui, RandomNumberGenerator rand)
        {
            _ui = ui;
            _rand = rand;
        }

        public int BirthDay(Npc npc) => (int)(npc.BirthDate % DaysInYear);

        public void BlockUntilTickCompletes(ChildPopulationTracker pop, Npc npc, long today)
        {
            if (TimeToDie(npc, today))
            {
                Die(pop, npc);
                return;
            }

            if (BirthDay(npc) == today % DaysInYear) _ui.NpcBirthday();
            if (CanGiveBirthToday(npc, today)) GiveBirth(pop, npc, today);
            if (CanGetPregnant(npc, today)) npc.LastImpregnatedOn = today;
            if (IsAdult(npc, today))
            {
                if (ProbabilityOfGettingANewTraitAtDay(npc.AgeInDays) >= _rand.GeneratePercentage())
                    npc.GiveTrait(new WandererTrait());
            }

            npc.AgeInDays++;
        }

        private bool TimeToDie(Npc npc, long today) => 
            npc.AgeInDays >= npc.Race.DiesAtAge;

        private bool CanGiveBirthToday(Npc npc, long today) =>
            npc.IsPregnant() && today >= npc.LastImpregnatedOn + npc.Race.PregnancyDurationInDays;

        private void Die(ChildPopulationTracker pop, Npc npc)
        {
            _ui.NpcDeath();
            pop.Remove(npc);
        }

        public bool IsFertile(Npc npc)
        {
            return
                npc.AgeInDays >= npc.Race.StartOfFertility &&
                npc.AgeInDays < npc.Race.EndOfFertility;
        }

        // todo: use calculus to return what the equasion should be when the cdf (or more accurately, integral of f(g)) goes from
        // f(g)=0 when g= (350*18) to f(g)=0.10 when g = (350*80) instead of just approximating a hard coded value
        //
        // using a hard coded value assumes an equal chance that someone will gain a trait throughout their life
        // but I believe people are more likely to get their traits sooner in life
        public double ProbabilityOfGettingANewTraitAtDay(int ageInDays) =>
             0.00001f;   //small probability of occurring each day

        private void GiveBirth(ChildPopulationTracker pop, Npc mother, long day)
        {
            ResetPregnancy(mother, day);
            pop.GenerateNewNpc(mother, null, day); //todo: determine who the father is?
        }

        public void ResetPregnancy(Npc npc, long today)
        {
            npc.LastPregnancyEnded = today;
            npc.LastImpregnatedOn = 0;
        }

        private bool CanGetPregnant(Npc npc, long today)   // todo: verify that a mate is nearby?
        {
            return (
                npc.Sex == Sex.Female &&
                IsFertile(npc) &&
                !npc.IsPregnant() &&
                npc.LastPregnancyEnded + npc.Race.TimeBetweenPregnancies <= today);
        }

        public bool IsAdult(Npc npc, long today) =>
            npc.AgeInDays >= npc.Race.AdulthoodBeginsAt;


    }

}




