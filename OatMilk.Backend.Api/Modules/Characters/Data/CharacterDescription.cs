using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Data
{
    public class CharacterDescription : IChildEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}