using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Services
{
    public class PopulationService
    {
        private readonly RandomNumberGenerator _rand;
        private readonly WorldState _worldState;

        public PopulationService(RandomNumberGenerator rand, WorldState worldState)
        {
            _rand = rand;
            _worldState = worldState;
        }        

        public void GenerateNewNpc(Npc mother, Npc? father)
        {
            var newNpc = new Npc(mother, father);

            newNpc.Sex = GenerateNewbornsBiologicalSex();

            string newName = Guid.NewGuid().ToString();

            if (newNpc.Sex == Sex.Male) newName = mother.Culture.GetRandomMaleName();
            if (newNpc.Sex == Sex.Female) newName = mother.Culture.GetRandomFemaleName();

            newNpc.FirstName = newName;
            
            newNpc.LastName = father?.LastName;                 //todo: better last name generation;  and culture = matrilineal vs patrilineal?
            newNpc.BirthDate = _worldState.CurrentDate;

            _worldState.AddZonedNpc(newNpc);
        }

        private Sex GenerateNewbornsBiologicalSex()
        {
            Sex newSex = Sex.None;

            var randomInt = _rand.GenerateBetween(0, 1);

            if (randomInt == 0) newSex = Sex.Female;
            if (randomInt == 1) newSex = Sex.Male;

            return newSex;
        }
    }
}
