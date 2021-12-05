using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using MongoDB.Bson;
using Newtonsoft.Json;
using NUnit.Framework;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Characters.Domain;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests.Spells;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses.Spells;
using OatMilk.Backend.Api.Modules.Shared.Pagination;
using OatMilk.Backend.Api.Modules.Spells.Data.Enums;
using OatMilk.Backend.Api.Tests.TestingHelpers;

namespace OatMilk.Backend.Api.Tests.Modules.Characters
{
    [TestFixture]
    public class CharacterServiceTests
    {
        private class Fixture : UserEntityRepositoryFixture<Character>
        {
            public Fixture(ObjectId userId, params Character[] characters) : base(userId, characters) { }
            
            public CharacterService GetSut()
            {
                return new(MockUserRepository.Object, Mapper);
            }
        }

        #region GetByIdentifier

        [Test]
        public async Task GetByIdentifierAsync_CharacterWithMinimalData_ReturnsName()
        {
            const string expectedIdentifier = "TestId";
            const string expectedName = "Test";
            var expectedUserId = ObjectId.GenerateNewId(); 
            var sut = new Fixture(expectedUserId, new Character()
            {
                Id = ObjectId.GenerateNewId(),
                Identifier = expectedIdentifier,
                Name = expectedName,
                UserId = expectedUserId,
            }).GetSut();
            
            var character = await sut.GetByIdentifierAsync(expectedIdentifier);
            
            Assert.AreEqual(expectedName, character.Name);
        }
        
        [Test]
        public async Task GetByIdentifierAsync_CharacterWithExperience_ReturnsLevelInfo()
        {
            const int expectedExperience = 100000;
            const string expectedIdentifier = "TestId";
            const string expectedName = "Test";
            var expectedUserId = ObjectId.GenerateNewId(); 
            var sut = new Fixture(expectedUserId, new Character()
            {
                Id = ObjectId.GenerateNewId(),
                Identifier = expectedIdentifier,
                Name = expectedName,
                UserId = expectedUserId,
                Attributes = new List<CharacterAttribute>()
                {
                    new()
                    {
                        Id = "experience",
                        Name = "Experience",
                        CurrentValue = expectedExperience
                    }
                }
            }).GetSut();
            
            var character = await sut.GetByIdentifierAsync(expectedIdentifier);
            
            Assert.AreEqual(expectedExperience, character.Level.Experience);
            Assert.AreEqual(12, character.Level.Number);
            Assert.AreEqual(100000, character.Level.CurrentLevelExperienceRequirement);
            Assert.AreEqual(120000, character.Level.NextLevelExperienceRequirement);
        }

        #endregion

        #region GetMultipleAsync

        [Test]
        public async Task GetMultipleAsync_OneCharacterWithMinimalData_ReturnsCharacterWithName()
        {
            const string expectedName = "Test";
            var expectedUserId = ObjectId.GenerateNewId(); 
            var sut = new Fixture(expectedUserId, new Character()
            {
                Id = ObjectId.GenerateNewId(),
                Name = expectedName,
                UserId = expectedUserId,
            }).GetSut();
            
            var characters = await sut.GetMultipleAsync(new SearchableSortedPageFilter());
            
            Assert.AreEqual(1, characters.TotalCount);
            Assert.AreEqual(expectedName, characters.Items.FirstOrDefault()?.Name);
        }

        #endregion
        
        #region CreateAsync

        [Test]
        public async Task CreateAsync_NameSpecified_ReturnsCharacterWithName()
        {
            var expectedUserId = ObjectId.GenerateNewId(); 
            const string expectedName = "Test";
            
            var sut = new Fixture(expectedUserId).GetSut();
            var character = await sut.CreateAsync(new CharacterRequest(){ Name = expectedName });
            
            Assert.AreEqual(expectedName, character.Name);
        }

        [Test]
        public async Task CreateAsync_NoDefaultsSpecified_ReturnsCharacterWithDefaults()
        {
            
            var expectedUserId = ObjectId.GenerateNewId(); 
            
            var sut = new Fixture(expectedUserId).GetSut();
            var character = await sut.CreateAsync(new CharacterRequest(){ Name = "Test" });
            
            Console.WriteLine(JsonConvert.SerializeObject(character, Formatting.Indented));
            
            Assert.AreEqual(6, character.Attributes.Count());
            Assert.AreEqual(6, character.AbilityScores.Count());
            Assert.AreEqual(18, character.AbilityScores.SelectMany(a => a.Proficiencies).Count());
            Assert.AreEqual(7, character.Descriptions.Count());
        }
        
        [Test]
        public async Task CreateAsync_RequestWithSpells_ReturnsCharacterWithSpells()
        {
            var expectedUserId = ObjectId.GenerateNewId(); 
            
            var sut = new Fixture(expectedUserId).GetSut();
            var character = await sut.CreateAsync(new CharacterRequest(){ Name = "Test", Spells = new List<CharacterSpellRequest>()
            {
                new ()
                {
                    Id = "spell1",
                    Description = "This is a spell",
                    Name = "Spell 1",
                    ShouldCreateNewId = false,
                    Duration = new CharacterSpellDurationRequest()
                    {
                        Value = 1,
                        Type = SpellDurationType.Action,
                        Description = null,
                    },
                    School = SpellSchool.Divination,
                    Components = new CharacterSpellComponentsRequest()
                    {
                        Verbal = true,
                        Somatic = true,
                        Material = true,
                    }
                }
            } });
            
            Console.WriteLine(JsonConvert.SerializeObject(character.Spells, Formatting.Indented));
            Assert.AreEqual(1, character.Spells.Count());
            Assert.IsNotNull(character.Spells[0].Components);
            Assert.IsNotNull(character.Spells[0].Duration);
        }
        
        [Test]
        public async Task CreateAsync_RequestWithSpellWithGenerateId_ReturnsCharacterWithSpellWithNewId()
        {
            var expectedUserId = ObjectId.GenerateNewId(); 
            
            var sut = new Fixture(expectedUserId).GetSut();
            var character = await sut.CreateAsync(new CharacterRequest(){ Name = "Test", Spells = new List<CharacterSpellRequest>()
            {
                new ()
                {
                    Id = "spell1",
                    Name = "Spell 1",
                    Description = "This is a spell",
                    ShouldCreateNewId = true,
                }
            } });
            
            Console.WriteLine(JsonConvert.SerializeObject(character.Spells, Formatting.Indented));
            Assert.IsTrue(!character.Spells[0].Id.IsNullOrEmpty());
        }

        #endregion

        #region UpdateAsync

        [Test]
        public async Task UpdateAsync_ExistingCharacterNoDefaults_ReturnsCharacterWithDefaults()
        {
            var expectedId = ObjectId.GenerateNewId();
            var expectedUserId = ObjectId.GenerateNewId(); 
            const string expectedName = "Test";
            
            var sut = new Fixture(expectedUserId, new Character(){ Id = expectedId, Name = "TestBefore" }).GetSut();
            var character = await sut.UpdateAsync(expectedId, new CharacterRequest(){ Name = expectedName });
            
            Console.WriteLine(JsonConvert.SerializeObject(character, Formatting.Indented));
            
            Assert.AreEqual(expectedName, character.Name);
            Assert.AreEqual(6, character.Attributes.Count());
            Assert.AreEqual(6, character.AbilityScores.Count());
            Assert.AreEqual(18, character.AbilityScores.SelectMany(a => a.Proficiencies).Count());
            Assert.AreEqual(7, character.Descriptions.Count());
        }

        #endregion
    }
}