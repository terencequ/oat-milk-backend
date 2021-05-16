using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Tests.TestingHelpers;
using Attribute = OatMilk.Backend.Api.Data.Entities.Attribute;

namespace OatMilk.Backend.Api.Tests.Services
{
    [TestFixture]
    public class CharacterServiceTests
    {
        private class Fixture : RepositoryFixture<Character>
        {
            private readonly Mock<IRepository<Ability>> _mockModifierRepository;

            public Fixture(params Character[] effects) : base(effects) { }
            
            public Fixture(Ability[] abilities, Character[] effects) : base(effects)
            {
                _mockModifierRepository = new Mock<IRepository<Ability>>();
                _mockModifierRepository.Setup(m => m.Get()).Returns(abilities.AsQueryable().BuildMock().Object);
            }

            public CharacterService GetSut()
            {
                return new(MockRepository.Object, _mockModifierRepository?.Object, Mapper);
            }
        }

        #region SetupAttributes

        [Test]
        public async Task SetupAttributes_ValidParameters_ShouldPopulateAttributes()
        {
            var expectedId = Guid.NewGuid();
            var result = await new Fixture(new Character()
            {
                Id = expectedId,
                Attributes = new List<Attribute>()
            }).GetSut().SetupAttributes(expectedId);
            
            Assert.IsTrue(result.Attributes.Any());
        }

        #endregion

    }
}