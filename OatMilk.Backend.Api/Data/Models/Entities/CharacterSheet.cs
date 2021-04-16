using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Data.Models.Entities
{
    public class CharacterSheet
    {
        // Hit Points
        public int BaseHitPoints { get; set; }

        // Stats
        public int BaseStrength { get; set; }
        public int BaseDexterity { get; set; }
        public int BaseConstitution { get; set; }
        public int BaseIntelligence { get; set; }
        public int BaseWisdom { get; set; }
        public int BaseCharisma { get; set; }

        // Misc Stats
        public int Inspiration { get; set; }
        public int ProficiencyBonus { get; set; } // Dynamic
        public int BaseArmorClass { get; set; } // Dynamic
        public int Initiative { get; set; }
        public int BaseSpeed { get; set; } // Dynamic

        // Skills
        public bool BaseAcrobatics { get; set; }
        public bool BaseAnimalHandling { get; set; }
        public bool BaseArcana { get; set; }
        public bool BaseAthletics { get; set; }
        public bool BaseDeception { get; set; }
        public bool BaseHistory { get; set; }
        public bool BaseInsight { get; set; }
        public bool BaseIntimidation { get; set; }
        public bool BaseMedicine { get; set; }
        public bool BaseNature { get; set; }
        public bool BasePerception { get; set; }
        public bool BasePerformance { get; set; }
        public bool BasePersuasion { get; set; }
        public bool BaseReligion { get; set; }
        public bool BaseSleightOfHand { get; set; }
        public bool BaseStealth { get; set; }
        public bool BaseSurvival { get; set; }
    }
}
