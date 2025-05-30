using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Traits;
using System.ComponentModel.DataAnnotations;

namespace FantasyPopulationSimulator.Console.Services
{
    public class WorldService
    {
        private readonly TravelService _travel;
        private readonly WorldState _worldState;
        private readonly NpcBehavior _behavior;
        private readonly RandomNumberGenerator _rng;
        private readonly NpcTraitService _npcTraitSvc;

        public WorldService(TravelService travel, WorldState worldState, NpcBehavior behavior, RandomNumberGenerator rng, NpcTraitService npcTraitSvc)
        {
            _travel = travel;
            _worldState = worldState;
            _behavior = behavior;
            _rng = rng;
            _npcTraitSvc = npcTraitSvc;
        }

        public long GetNpcCount(WorldState _worldState)
        {
            long sum = 0;

            sum += _worldState.GetAllZonedNpcs().Count;
            sum += _worldState.GetAllTravellers().Count;

            return sum;
        }

        public List<Npc> RandomlySamplePercentageOfList(List<Npc> list, float percentage)
        {
            int sampleSize = (int)(list.Count * percentage);
            var indices = Enumerable.Range(0, list.Count)
                .OrderBy(_ => _rng.GenerateBetween(int.MinValue, int.MaxValue))
                .Take(sampleSize);

            List<Npc> sampled = indices.Select(i => list[i]).ToList();
            return sampled;
        }

        public void BlockUntilTickCompletes(WorldState _worldState)
        {
            _travel.CompleteTravellerJourneys();
            var exclusionList = new List<Npc>();

            ProcessDeaths(exclusionList);
            ProcessTraitRelatedTick(exclusionList);
            ProcessBirthers(exclusionList);
            ProcessFertile(exclusionList);
            ProcessTraitAssignment(exclusionList);
        }

        private void ProcessTraitAssignment(List<Npc> exclusionList)
        {
            var npcs = (from npc in _worldState.GetAllZonedNpcs()
                        where !exclusionList.Contains(npc) && !npc.IsDead && _behavior.IsAdult(npc)
                        select npc).ToList();

            foreach (Npc npc in npcs)
            {
                var ageInDays = _behavior.GetAgeInDays(npc);
                if (
                    !npc.HasTrait(TraitEnum.Settler) &&
                    !npc.HasTrait(TraitEnum.Wanderer) &&
                    _behavior.ProbabilityOfGettingANewTraitAtDay(ageInDays) >= _rng.GeneratePercentage())
                    _npcTraitSvc.AddTraitToNpc(npc, TraitEnum.Wanderer);
            }
        }

        private void ProcessFertile(List<Npc> exclusionList)
        {
            var fertileNpcs = (from npc in _worldState.GetAllZonedNpcs()
                               where
                                   !exclusionList.Contains(npc) &&
                                   !npc.IsDead &&
                                   _behavior.CanGetPregnant(npc)
                               select npc).ToList();
            foreach (Npc npc in fertileNpcs)
            {
                npc.LastImpregnatedOn = _worldState.CurrentDate;
                exclusionList.Add(npc);
            }
        }

        private void ProcessBirthers(List<Npc> exclusionList)
        {
            var preggos = (from Npc npc in _worldState.GetAllZonedNpcs()
                           where
                              !exclusionList.Contains(npc) &&
                              !npc.IsDead &&
                              _behavior.CanGiveBirthToday(npc)
                           select npc).ToList();
            foreach (Npc npc in preggos)
            {
                _behavior.GiveBirth(npc);
                exclusionList.Add(npc);
            }
        }

        private void ProcessTraitRelatedTick(List<Npc> exclusionList)
        {
            var potentialWanderers = (from Npc npc in _worldState.GetAllZonedNpcs() 
                                      where 
                                        !exclusionList.Contains(npc) && 
                                        npc.Traits.ContainsKey(TraitEnum.Wanderer) 
                                      select npc).ToList();
            var selected = RandomlySamplePercentageOfList(potentialWanderers, 0.1f);
            var wandererTrait = _worldState.GetTraitByEnum(TraitEnum.Wanderer);
            foreach (Npc npc in selected)
            {
                if (!wandererTrait.ProcessTickAndContinue(npc)) exclusionList.Add(npc);
            }
        }

        private void ProcessDeaths(List<Npc> exclusionList)
        {
            var DeathQueue = (from npc in _worldState.GetAllZonedNpcs() where _behavior.GetAgeInDays(npc) >= npc.Race.DiesAtAge select npc).ToList();
            foreach (Npc npc in DeathQueue)
            {
                npc.IsDead = true;
                _worldState.RemoveZonedNpc(npc);
                _worldState.RemoveNpcTraveller(npc);
                exclusionList.Add(npc);
            }
        }

        public void MoveNpcToTravellers(Traveller traveller)
        {
            string sourceZoneName = traveller!.TravellerNpc!.CurrentZone!.ZoneName;

            _worldState.RemoveZonedNpc(traveller!.TravellerNpc);
            _worldState.AddTraveller(traveller);
        }
    }
}
