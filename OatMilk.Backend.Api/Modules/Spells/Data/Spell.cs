using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Spells.Data
{
    public class Spell
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public SpellCastingTime CastingTime { get; set; }
        public SpellRange Range { get; set; }
        public SpellComponents Components { get; set; }
        public SpellDuration Duration { get; set; }
        public SpellSchool School { get; set; }
    }
}