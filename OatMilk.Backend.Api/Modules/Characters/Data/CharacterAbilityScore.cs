using System.Collections.Generic;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Data
{
    public class CharacterAbilityScore : IChildEntity
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