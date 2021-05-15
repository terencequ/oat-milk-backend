using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Data.Entities
{
    public class Character : UserEntity // TODO: convert attributes to attribute sets
    {
        #region Experience

        public int Experience { get; set; }

        #endregion

        #region Stats

        // Stats
        public Attribute HitPoints { get; set; }
        public ICollection<Attribute> HitDice { get; set; }
        public Attribute ArmorClass { get; set; }
        public Attribute Speed { get; set; }
        
        public Attribute DeathSaveSuccesses { get; set; }
        public Attribute DeathSaveFailures { get; set; }
        
        public Attribute Strength { get; set; }
        public Attribute Dexterity { get; set; }
        public Attribute Constitution { get; set; }
        public Attribute Intelligence { get; set; }
        public Attribute Wisdom { get; set; }
        public Attribute Charisma { get; set; }

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