using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Data.Entities
{
    public class Character : UserEntity // TODO: convert attributes to attribute sets
    {
        #region Experience

        public int Experience { get; set; }

        #endregion

        #region Stats and Attributes
        
        public ICollection<Attribute> Attributes { get; set; }

        /// <summary>
        /// Remove all attributes from character.
        /// </summary>
        public void ClearAttributes()
        {
            foreach (var attribute in Attributes)
            {
                Attributes.Remove(attribute);
            }
        }
        
        /// <summary>
        /// Set up attributes for a blank character.
        /// </summary>
        public void ResetAndSetupAttributes()
        {
            var attributeTypes = new string[]
            {
                "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma", "HitPoints", 
                "ArmorClass", "Speed", "DeathSaveSuccesses", "DeathSaveFailures"
            };
            ClearAttributes();
            foreach (var type in attributeTypes)
            {
                Attributes.Add(new Attribute()
                {
                    Type = type,
                    BaseValue = 0,
                    CurrentValue = 0,
                    CreatedDateTimeUtc = DateTime.UtcNow,
                    UpdatedDateTimeUtc = DateTime.UtcNow
                });
            }
        }

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