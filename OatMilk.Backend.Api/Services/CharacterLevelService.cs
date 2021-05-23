﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services
{
    public class CharacterLevelService : UserEntityService<CharacterLevelRequest, Level, CharacterLevelResponse>, ICharacterLevelService
    {
        public CharacterLevelService(IRepository<Level> repository, IMapper mapper) : base(repository, mapper) { }
        
        public async Task<ICollection<CharacterLevelResponse>> ResetLevels()
        {
            for (int i = 0; i < LevelExperience.Length; i++)
            {
                // Create level definition
                var level = i + 1;
                var characterLevel = new Level()
                {
                    Name = $"Level {level}",
                    Number = level,
                    ExperienceRequirement = LevelExperience[i],
                    ProficiencyBonus = GetProficiencyBonusForLevel(level),
                    CreatedDateTimeUtc = DateTime.UtcNow,
                    UpdatedDateTimeUtc = DateTime.UtcNow
                };
                Repository.Add(characterLevel);
                await Repository.SaveAsync();
            }

            // Get all levels and return them as a list
            var characterLevels = Repository
                .Get()
                .OrderBy(level => level.CreatedDateTimeUtc)
                .ProjectTo<CharacterLevelResponse>(Mapper.ConfigurationProvider)
                .ToList();
            return characterLevels;
        }

        #region Static Helpers

        public static int[] LevelExperience = new int[]
        {
            0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000,
            225000, 265000, 305000, 355000
        };

        public static int GetProficiencyBonusForLevel(int level)
        {
            return (int) Math.Ceiling(1d + (level / 4d));
        }

        #endregion
    }
}