using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Traits;

namespace FantasyPopulationSimulator.Console.Services
{


    public class TraitCatalogue
    {
        private Dictionary<TraitEnum, ITrait> Traits { get; set; } = new Dictionary<TraitEnum, ITrait>();


        public TraitCatalogue(WandererTrait wandererTrait, SettlerTrait settlerTrait)
        {
            Traits.Add(TraitEnum.Wanderer, wandererTrait);
            Traits.Add(TraitEnum.Settler, settlerTrait);

            Traits.Add(TraitEnum.Brave, null);
            Traits.Add(TraitEnum.Craven, null);
            
            Traits.Add(TraitEnum.Calm, null);
            Traits.Add(TraitEnum.Wrathful, null);
            
            Traits.Add(TraitEnum.Chaste, null);
            Traits.Add(TraitEnum.Lustful, null);

            Traits.Add(TraitEnum.Content, null);
            Traits.Add(TraitEnum.Ambitious, null);

            Traits.Add(TraitEnum.Diligent, null);
            Traits.Add(TraitEnum.Lazy, null);

            Traits.Add(TraitEnum.Forgiving, null);
            Traits.Add(TraitEnum.Vengeful, null);

            Traits.Add(TraitEnum.Generous, null);
            Traits.Add(TraitEnum.Greedy, null);

            Traits.Add(TraitEnum.Gregarious, null);
            Traits.Add(TraitEnum.Shy, null);

            Traits.Add(TraitEnum.Honest, null);
            Traits.Add(TraitEnum.Deceitful, null);

            Traits.Add(TraitEnum.Humble, null);
            Traits.Add(TraitEnum.Arrogant, null);

            Traits.Add(TraitEnum.Just, null);
            Traits.Add(TraitEnum.Arbitrary, null);

            Traits.Add(TraitEnum.Patient, null);
            Traits.Add(TraitEnum.Impatient, null);

            Traits.Add(TraitEnum.Temperant, null);
            Traits.Add(TraitEnum.Gluttonous, null);
            
            Traits.Add(TraitEnum.Trusting, null);
            Traits.Add(TraitEnum.Paranoid, null);

            Traits.Add(TraitEnum.Zealous, null);
            Traits.Add(TraitEnum.Cynical, null);

            Traits.Add(TraitEnum.Compassionate, null);
            Traits.Add(TraitEnum.Sadistic, null);
        }

        public ITrait GetTraitByEnum(TraitEnum trait)
        {
            if (Traits.TryGetValue(trait, out ITrait? value)) return value;
            throw new ApplicationException($"Trait {trait} not found in catalogue.");
        }
    }
}
