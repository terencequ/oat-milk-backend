﻿using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Tests.TestingHelpers;

namespace OatMilk.Backend.Api.Tests.Services
{
    [TestFixture]
    public class AbilityServiceTests
    {
        private class Fixture : RepositoryFixture<Ability>
        {
            public Fixture(params Ability[] abilities) : base(abilities) { }
            
            public AbilityService GetSut()
            {
                return new(Configuration, MockRepository.Object, Mapper);
            }
        }
        
        #region CraeteAbility

        [Test]
        public async Task CreateAbilityForUser_ValidParameters_ShouldReturnGuid()
        {
            var service = new Fixture().GetSut();
            var result = await service.CreateAbility(new AbilityRequest()
            {
                Name = "test name"
            });
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CreateAbilityForUser_NameAlreadyExists_ShouldThrowArgumentException()
        {
            var duplicateName = "test";
            
            var service = new Fixture(new Ability(){ Name = duplicateName }).GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await service.CreateAbility(new AbilityRequest()
                {
                    Name = duplicateName
                });
            });
        }

        #endregion
    }
}