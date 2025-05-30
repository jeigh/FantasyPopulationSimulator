﻿using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class RacialAntagonismTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.RacialAntagonism;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
