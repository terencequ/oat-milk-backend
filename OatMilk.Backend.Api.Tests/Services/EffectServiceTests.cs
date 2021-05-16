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

namespace OatMilk.Backend.Api.Tests.Services
{
    [TestFixture]
    public class EffectServiceTests
    {
        private class Fixture : RepositoryFixture<Effect>
        {
            private readonly Mock<IRepository<Modifier>> _mockModifierRepository;

            public Fixture(params Effect[] effects) : base(effects) { }
            
            public Fixture(Modifier[] modifiers, Effect[] effects) : base(effects)
            {
                _mockModifierRepository = new Mock<IRepository<Modifier>>();
                _mockModifierRepository.Setup(m => m.Get()).Returns(modifiers.AsQueryable().BuildMock().Object);
            }

            public EffectService GetSut()
            {
                return new(MockRepository.Object, _mockModifierRepository?.Object, Mapper);
            }
        }

        #region CreateModifier

        [Test]
        public async Task CreateAndAssignModifier_ValidParameters_ReturnsModifier()
        {
            var expectedId = Guid.NewGuid();
            var expectedAttribute = "test";
            var sut = new Fixture(new Effect(){Id = expectedId, Modifiers = new List<Modifier>()}).GetSut();
            var result = await sut.CreateModifier(expectedId, new ModifierRequest(){ Attribute = expectedAttribute });
            
            Assert.AreEqual(expectedAttribute, result.Attribute);
        }
        
        #endregion
        
        #region DeleteModifier
        
        [Test]
        public async Task DeleteModifier_ValidParameters_ReturnsModifier()
        {
            var expectedModifier = new Modifier()
            {
                Id = Guid.NewGuid()
            };
            var expectedEffect = new Effect()
            {
                Id = Guid.NewGuid(),
                Modifiers = new List<Modifier>()
                {
                    expectedModifier
                }
            };
            var sut = new Fixture(new []{expectedModifier}, new []{expectedEffect}).GetSut();
            var result = await sut.DeleteModifer(expectedEffect.Id, expectedModifier.Id);
            
            Assert.AreEqual(expectedModifier.Id, result.Id);
        }

        [Test]
        public void DeleteModifier_ModifierDoesntExist_ThrowsArgumentException()
        {
            var expectedEffect = new Effect()
            {
                Id = Guid.NewGuid(),
                Modifiers = new List<Modifier>() { }
            };
            var sut = new Fixture(Array.Empty<Modifier>(), new []{expectedEffect}).GetSut();

            Assert.ThrowsAsync<ArgumentException>(async () => await sut.DeleteModifer(expectedEffect.Id, Guid.Empty));
        }
        
        #endregion
    }
}