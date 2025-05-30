using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Traits;

namespace FantasyPopulationSimulator.Console.Services
{
    public class InitialSetupHelper
    {
        private readonly ZoneManagement _zones;
        private readonly WorldState _worldState;
        private readonly WandererTrait _wander;
        private readonly SettlerTrait _settler;


        public InitialSetupHelper(ZoneManagement zones, WorldState worldState, WandererTrait wandererTrait, SettlerTrait settlerTrait)
        {
            _zones = zones;
            _wander = wandererTrait;
            _settler = settlerTrait;

            _worldState = worldState;
            LoadTraits(_wander, _settler);
        }

        public void SetupEverquestThemedZones(Zone edenZone, Zone darkElfEden)
        {
            Zone freeportZone = CreateAndTrackNewZone("Freeport");
            Zone eastCommonlandsZone = CreateAndTrackNewZone("East Commonlands");
            Zone neriakZone = CreateAndTrackNewZone("Neriak");
            Zone nektulosZone = CreateAndTrackNewZone("Nektulos Forest");

            _zones.AddAdjacentZone(edenZone, freeportZone, twoWayConnection: false);
            _zones.AddAdjacentZone(freeportZone, eastCommonlandsZone, twoWayConnection: true);
            _zones.AddAdjacentZone(eastCommonlandsZone, nektulosZone, twoWayConnection: true);
            _zones.AddAdjacentZone(nektulosZone, neriakZone, twoWayConnection: true);
            _zones.AddAdjacentZone(darkElfEden, neriakZone, twoWayConnection: false);
        }

        public Zone CreateAndTrackNewZone(string zoneName)
        {
            var newZone = _zones.CreateNewZone(zoneName);
            return newZone;
        }

        public void GenerateAdam(IZone currentZone, IRace race, ICulture culture, string name)
        {
            var adam = new Npc(race, culture, currentZone);

            adam.FirstName = name;
            adam.BirthDate = -16 * DaysInYear + 36;
            adam.Sex = Sex.Male;

            _worldState.AddZonedNpc(adam);
            
        }

        public void GenerateEve(IZone currentZone, IRace race, ICulture culture, string name)
        {
            var eve = new Npc(race, culture, currentZone);

            eve.FirstName = name;
            eve.BirthDate = -16 * DaysInYear + 17;
            eve.Sex = Sex.Female;
            
            _worldState.AddZonedNpc(eve);
        }

        public Zone CreateStartingZoneForEden(ZoneManagement zones, string zoneName, IRace race, ICulture culture, string prefix)
        {
            var returnable = zones.CreateNewZone(zoneName);

            GenerateAdam( returnable, race, culture, $"{prefix}Adam");
            GenerateEve(returnable, race, culture, $"{prefix}Eve");

            return returnable;
        }

        public void LoadTraits(WandererTrait wandererTrait, SettlerTrait settlerTrait)
        {
            _worldState.Traits.Add(TraitEnum.Wanderer, wandererTrait);
            _worldState.Traits.Add(TraitEnum.Settler, settlerTrait);

            _worldState.Traits.Add(TraitEnum.Brave, null);
            _worldState.Traits.Add(TraitEnum.Craven, null);

            _worldState.Traits.Add(TraitEnum.Calm, null);
            _worldState.Traits.Add(TraitEnum.Wrathful, null);

            _worldState.Traits.Add(TraitEnum.Chaste, null);
            _worldState.Traits.Add(TraitEnum.Lustful, null);

            _worldState.Traits.Add(TraitEnum.Content, null);
            _worldState.Traits.Add(TraitEnum.Ambitious, null);

            _worldState.Traits.Add(TraitEnum.Diligent, null);
            _worldState.Traits.Add(TraitEnum.Lazy, null);

            _worldState.Traits.Add(TraitEnum.Forgiving, null);
            _worldState.Traits.Add(TraitEnum.Vengeful, null);
            
            _worldState.Traits.Add(TraitEnum.Generous, null);
            _worldState.Traits.Add(TraitEnum.Greedy, null);
            
            _worldState.Traits.Add(TraitEnum.Gregarious, null);
            _worldState.Traits.Add(TraitEnum.Shy, null);
            
            _worldState.Traits.Add(TraitEnum.Honest, null);
            _worldState.Traits.Add(TraitEnum.Deceitful, null);
            
            _worldState.Traits.Add(TraitEnum.Humble, null);
            _worldState.Traits.Add(TraitEnum.Arrogant, null);
            
            _worldState.Traits.Add(TraitEnum.Just, null);
            _worldState.Traits.Add(TraitEnum.Arbitrary, null);
            
            _worldState.Traits.Add(TraitEnum.Patient, null);
            _worldState.Traits.Add(TraitEnum.Impatient, null);
            
            _worldState.Traits.Add(TraitEnum.Temperant, null);
            _worldState.Traits.Add(TraitEnum.Gluttonous, null);
            
            _worldState.Traits.Add(TraitEnum.Trusting, null);
            _worldState.Traits.Add(TraitEnum.Paranoid, null);
            
            _worldState.Traits.Add(TraitEnum.Zealous, null);
            _worldState.Traits.Add(TraitEnum.Cynical, null);
            
            _worldState.Traits.Add(TraitEnum.Compassionate, null);
            _worldState.Traits.Add(TraitEnum.Sadistic, null);
        }

    }
}
