using System.Collections.Generic;

namespace OatMilk.Backend.Api.Modules.Characters.Data
{
    public class CharacterAbilityScore
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public bool Proficient { get; set; }
        public bool Expertise { get; set; }

        public ICollection<CharacterAbilityScoreProficiency> Proficiencies { get; set; } =
            new List<CharacterAbilityScoreProficiency>();
    }
}