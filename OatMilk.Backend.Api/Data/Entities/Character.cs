using System.Collections.Generic;
using System.Collections.Immutable;

namespace OatMilk.Backend.Api.Data.Entities
{
    public static class CharacterConstants
    {
        public static readonly ImmutableArray<int> ExperienceRequirements = new()
        {
            0, 300, 900, 2700, // Lvl 1 to 4
            6500, 14000, 23000, 24000, // Lvl 5 - 8
            48000, 64000, 85000, 100000, // Lvl 9 to 12
            120000, 140000, 165000, 196000, // Lvl 13 to 16
            225000, 265000, 305000, 355000 // Lvl 17 to 20
        };

        public static readonly ImmutableArray<int> ProficiencyBonus = new()
        {
            2, 2, 2, 2,
            3, 3, 3, 3,
            4, 4, 4, 4,
            5, 5, 5, 5,
            6, 6, 6, 6
        };
    }
    
    public class Character
    {
        public int Experience { get; set; }
        public int Level => 1;
        public int Proficiency { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        
        public bool Acrobatics { get; set; }
        public bool AnimalHandling { get; set; }
        public bool Arcana { get; set; }
        public bool Athletics { get; set; }
        public bool Deception { get; set; }
        public bool History { get; set; }
        public bool Insight { get; set; }
        public bool Intimidation { get; set; }
        public bool Investigation { get; set; }
        public bool Medicine { get; set; }
        public bool Nature { get; set; }
        public bool Perception { get; set; }
        public bool Religion { get; set; }
        public bool SleightOfHand { get; set; }
        public bool Stealth { get; set; }
        public bool Survival { get; set; }

        public int AcrobaticsModifier => Strength + (Acrobatics ? 0 : Proficiency);
        public int AnimalHandlingModifier => Wisdom + (AnimalHandling ? 0 : Proficiency);
        public int ArcanaModifier { get; set; }
        public int AthleticsModifier { get; set; }
        public int DeceptionModifier { get; set; }
        public int HistoryModifier { get; set; }
        public int InsightModifier { get; set; }
        public int IntimidationModifier { get; set; }
        public int InvestigationModifier { get; set; }
        public int MedicineModifier { get; set; }
        public int NatureModifier { get; set; }
        public int PerceptionModifier { get; set; }
        public int ReligionModifier { get; set; }
        public int SleightOfHandModifier { get; set; }
        public int StealthModifier { get; set; }
        public int SurvivalModifier { get; set; }
    }
}