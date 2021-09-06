using System.Collections.Generic;
using System.Linq;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Helpers
{
    public static class LevelHelper
    {
        /// <summary>
        /// Data class for level definition.
        /// </summary>
        private record LevelDefinition
        {
            public int Level { get; set; }
            public int ExperienceRequirement { get; set; }

            public LevelDefinition(int level, int experienceRequirement)
            {
                Level = level;
                ExperienceRequirement = experienceRequirement;
            }
        }
        
        private const int MinLevel = 1;
        private const int MaxLevel = 20;
        
        private static readonly List<LevelDefinition> Levels = new ()
        {
            new (1, 0),
            new (2, 300),
            new (3, 900),
            new (4, 2700),
            new (5, 6500),
            new (6, 14000),
            new (7, 23000),
            new (8, 34000),
            new (9, 48000),
            new (10, 64000),
            new (11, 85000),
            new (12, 100000),
            new (13, 120000),
            new (14, 140000),
            new (15, 165000),
            new (16, 195000),
            new (17, 225000),
            new (18, 265000),
            new (19, 305000),
            new (20, 355000),
        };

        public static int GetLevel(int currentExperience)
        {
            for (var level = MaxLevel; level >= MinLevel; level--)
            {
                var experienceRequirement = Levels.Single(l => l.Level == level).ExperienceRequirement;
                if (experienceRequirement <= currentExperience)
                {
                    return level;
                }
            }

            return -1; // Special number which symbolises that no valid level was found.
        }
        
        public static int GetNextLevelExperienceRequirement(int currentExperience)
        {
            for (var level = MinLevel; level <= MaxLevel; level++)
            {
                var experienceRequirement = Levels.Single(l => l.Level == level).ExperienceRequirement;
                if (experienceRequirement > currentExperience)
                {
                    return experienceRequirement;
                }
            }

            return -1; // Special number which symbolises "MAX"
        }
        
        public static int GetPreviousLevelExperienceRequirement(int currentExperience)
        {
            for (var level = MaxLevel; level >= MinLevel; level--)
            {
                var experienceRequirement = Levels.Single(l => l.Level == level).ExperienceRequirement;
                if (experienceRequirement <= currentExperience)
                {
                    return experienceRequirement;
                }
            }

            return 0;
        }

        public static int GetProficiencyBonus(int experience)
        {
            return Levels.Single(l => l.Level == GetLevel(experience)).ExperienceRequirement;
        }
    }
}