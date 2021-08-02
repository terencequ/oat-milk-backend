using System;
using System.Collections;
using System.Collections.Generic;

namespace OatMilk.Backend.Api.Services.Models.Responses
{
    public class CharacterResponse
    {
        #region Entity

        public Guid Id { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
        public string Name { get; set; }

        #endregion
        
        #region Experience

        public int Experience { get; set; }

        #endregion

        #region Stats and Attributes

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        
        public int ArmorClass { get; set; }
        public int Initiative { get; set; }
        public int SpeedInFt { get; set; }

        public int CurrentHitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        
        public int DeathSaveSuccesses { get; set; }
        public int DeathSaveFailures { get; set; }

        #endregion

        #region Proficiencies
        
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
        public bool Performance { get; set; }
        public bool Persuasion { get; set; }
        public bool Religion { get; set; }
        public bool SleightOfHand { get; set; }
        public bool Stealth { get; set; }
        public bool Survival { get; set; }

        #endregion

        #region Bio and flavour

        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public string Backstory { get; set; }
        public string AlliesAndOrganisations { get; set; }
        public string Appearance { get; set; }

        #endregion
    }
}