using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Data
{
    public class CharacterSpell : IChildEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public string CastingTime { get; set; }
        public string RangeOrArea { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string School { get; set; }
    }
}