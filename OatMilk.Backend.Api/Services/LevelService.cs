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
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Services
{
    public class LevelService : UserEntityService<LevelRequest, Level, LevelResponse>, ILevelService
    {
        public LevelService(IRepository<Level> repository, IMapper mapper) : base(repository, mapper) { }
        
        public async Task<PageResponse<LevelResponse>> ResetLevels()
        {
            foreach (var level in Repository.Get())
            {
                Repository.Remove(level);
            }
            
            for (int i = 0; i < LevelExperience.Length; i++)
            {
                // Create level definition
                var levelNumber = i + 1;
                var level = new Level()
                {
                    Name = $"Level {levelNumber}",
                    Number = levelNumber,
                    ExperienceRequirement = LevelExperience[i],
                    ProficiencyBonus = GetProficiencyBonusForLevel(levelNumber),
                    CreatedDateTimeUtc = DateTime.UtcNow,
                    UpdatedDateTimeUtc = DateTime.UtcNow
                };
                Repository.Add(level);
            }
            
            await Repository.SaveAsync();

            // Get all levels and return them as a list
            return await Repository
                .Get()
                .OrderBy(level => level.CreatedDateTimeUtc)
                .ProjectTo<LevelResponse>(Mapper.ConfigurationProvider)
                .GetPageResponseAsync(new PageFilter()
                {
                    PageIndex = 0, // Return all items in one page
                    PageSize = 0
                });
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