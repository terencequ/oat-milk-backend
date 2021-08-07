using System.Collections.Generic;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Helpers
{
    public static class LevelHelper
    {
        private const int MinLevel = 1;
        private const int MaxLevel = 20;
        
        private static readonly Dictionary<int, int> Levels = new ()
        {
            {1, 0},
            {2, 300},
            {3, 900},
            {4, 2700},
            {5, 6500},
            {6, 14000},
            {7, 23000},
            {8, 34000},
            {9, 48000},
            {10, 64000},
            {11, 85000},
            {12, 100000},
            {13, 120000},
            {14, 140000},
            {15, 165000},
            {16, 195000},
            {17, 225000},
            {18, 265000},
            {19, 305000},
            {20, 355000},
        };

        public static int GetLevel(int currentExperience)
        {
            for (var level = MaxLevel; level >= MinLevel; level--)
            {
                var experienceRequirement = Levels[level];
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
                var experienceRequirement = Levels[level];
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
                var experienceRequirement = Levels[level];
                if (experienceRequirement <= currentExperience)
                {
                    return experienceRequirement;
                }
            }

            return 0;
        }
    }
}