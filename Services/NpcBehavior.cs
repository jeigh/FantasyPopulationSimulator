using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Services
{

    public class NpcBehavior
    {
        private readonly RandomNumberGenerator _rand;
        private readonly PopulationService _pop;
        private readonly WorldState _worldState;
        private readonly NpcTraitService _npcTraitSvc;


        public NpcBehavior(RandomNumberGenerator rand,  PopulationService pop, WorldState worldState, NpcTraitService npcTraitSvc)
        {
            _rand = rand;
            _pop = pop;
            _worldState = worldState;
            _npcTraitSvc = npcTraitSvc;
        }

        public int BirthDay(Npc npc) => 
            (int)(npc.BirthDate % DaysInYear);

        public void BlockUntilTickCompletes(Npc npc, long today)
        {
            if (npc.IsDead) return;
            if (TimeToDie(npc, today))
            {
                Die(_pop, npc);
                return;
            }

            foreach (var trait in npc.Traits.Values.ToList())
            {
                if (!trait.ProcessTickAndContinue(npc, today)) 
                { 
                    npc.AgeInDays++; 
                    return; 
                }
            }

            //if (BirthDay(npc) == today % DaysInYear) _ui.NpcBirthday();
            if (CanGiveBirthToday(npc, today)) GiveBirth(npc, today);
            if (CanGetPregnant(npc, today)) npc.LastImpregnatedOn = today;
            if (IsAdult(npc, today))
            {
                if 
                    (
                        !npc.HasTrait(TraitEnum.Settler) && 
                        !npc.HasTrait(TraitEnum.Wanderer) &&  
                        ProbabilityOfGettingANewTraitAtDay(npc.AgeInDays) >= _rand.GeneratePercentage()
                    )
                    _npcTraitSvc.AddTraitToNpc(npc, TraitEnum.Wanderer);
            }

            npc.AgeInDays++;
        }

        private bool TimeToDie(Npc npc, long today) =>
            !npc.IsDead && 
            npc.AgeInDays >= npc.Race.DiesAtAge;

        private bool CanGiveBirthToday(Npc npc, long today) =>
            !npc.IsDead && 
            npc.IsPregnant() && 
            today >= npc.LastImpregnatedOn + npc.Race.PregnancyDurationInDays;

        private void Die(PopulationService pop, Npc npc)
        {
            npc.IsDead = true;
            _worldState.RemoveZonedNpc(npc);
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

        private void GiveBirth(Npc mother, long day)
        {
            if (mother.IsDead) return;
            ResetPregnancy(mother, day);
            _pop.GenerateNewNpc(mother, null, day); //todo: determine who the father is?
            mother.ChildrenCount++;
        }

        public void ResetPregnancy(Npc npc, long today)
        {
            npc.LastPregnancyEnded = today;
            npc.LastImpregnatedOn = 0;
        }

        private bool CanGetPregnant(Npc npc, long today)   // todo: verify that a mate is nearby?
        {
            return
                npc.Sex == Sex.Female &&
                IsFertile(npc) &&
                !npc.IsPregnant() &&
                npc.ChildrenCount < 4 &&  // this should probably be affected by a fertility trait
                npc.LastPregnancyEnded + npc.Race.TimeBetweenPregnancies <= today;
        }

        public bool IsAdult(Npc npc, long today) =>
            npc.AgeInDays >= npc.Race.AdulthoodBeginsAt;


    }
}




