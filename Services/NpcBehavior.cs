using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Services
{
    public class NpcBehavior
    {
        private readonly PopulationService _pop;
        private readonly WorldState _worldState;

        public NpcBehavior(PopulationService pop, WorldState worldState)
        {
            _pop = pop;
            _worldState = worldState;
        }

        public bool CanGiveBirthToday(Npc npc) =>
            !npc.IsDead && 
            npc.IsPregnant() && 
            _worldState.CurrentDate >= npc.LastImpregnatedOn + npc.Race.PregnancyDurationInDays;

        public long GetAgeInDays(Npc npc)
        {
            return _worldState.CurrentDate - npc.BirthDate;
        }


        public bool IsFertile(Npc npc)
        {
            var ageInDays = GetAgeInDays(npc);
            return
                ageInDays >= npc.Race.StartOfFertility &&
                ageInDays < npc.Race.EndOfFertility;
        }

        // todo: use calculus to return what the equasion should be when the cdf (or more accurately, integral of f(g)) goes from
        // f(g)=0 when g= (350*18) to f(g)=0.10 when g = (350*80) instead of just approximating a hard coded value
        //
        // using a hard coded value assumes an equal chance that someone will gain a trait throughout their life
        // but I believe people are more likely to get their traits sooner in life
        public double ProbabilityOfGettingANewTraitAtDay(long ageInDays) =>
             0.00001f;   //small probability of occurring each day

        public void GiveBirth(Npc mother)
        {
            if (mother.IsDead) return;
            ResetPregnancy(mother);
            _pop.GenerateNewNpc(mother, null); //todo: determine who the father is?
            mother.ChildrenCount++;
        }

        public void ResetPregnancy(Npc npc)
        {
            npc.LastPregnancyEnded = _worldState.CurrentDate;
            npc.LastImpregnatedOn = 0;
        }

        public bool CanGetPregnant(Npc npc)   // todo: verify that a mate is nearby?
        {
            return
                npc.Sex == Sex.Female &&
                IsFertile(npc) &&
                !npc.IsPregnant() &&
                npc.ChildrenCount < 4 &&  // this should probably be affected by a fertility trait
                npc.LastPregnancyEnded + npc.Race.TimeBetweenPregnancies <= _worldState.CurrentDate;
        }

        public bool IsAdult(Npc npc)
        {
            var ageInDays = GetAgeInDays(npc);
            return ageInDays >= npc.Race.AdulthoodBeginsAt;
        }
    }
}




