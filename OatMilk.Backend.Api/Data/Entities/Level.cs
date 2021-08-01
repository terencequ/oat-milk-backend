using System;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Data.Entities
{
    public class Level : UserEntity
    {
        public int Number { get; set; }
        public int ExperienceRequirement { get; set; }
        public int ProficiencyBonus { get; set; }
    }
}