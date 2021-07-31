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
                _mockModifierRepository.Setup(m => m.GetQueryable())
                    .Returns(modifiers.AsQueryable().BuildMock().Object);
                _mockModifierRepository.Setup(m => m.GetByIdQueryable(It.IsAny<Guid>()))
                    .Returns<Guid>(id => modifiers.AsQueryable().BuildMock().Object.Where(e => e.Id == id));
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

        #region UpdateModifier

        [Test]
        public async Task UpdateModifier_ValidParameters_ReturnsModifier()
        {
            var modifier = new Modifier()
            {
                Id = Guid.NewGuid()
            };
            var effect = new Effect()
            {
                Id = Guid.NewGuid(),
                Modifiers = new List<Modifier>()
                {
                    modifier
                }
            };

            var expectedAttribute = "test";
            var sut = new Fixture(new []{modifier}, new []{effect}).GetSut();
            var result = await sut.UpdateModifier(effect.Id, modifier.Id, new ModifierRequest()
            {
                Attribute = expectedAttribute,
            });
            
            Assert.AreEqual(modifier.Id, result.Id);
            Assert.AreEqual(expectedAttribute, result.Attribute);
        }

        [Test]
        public void UpdateModifier_ModifierDoesntExist_ThrowsArgumentException()
        {
            var expectedEffect = new Effect()
            {
                Id = Guid.NewGuid(),
                Modifiers = new List<Modifier>() { }
            };
            var sut = new Fixture(Array.Empty<Modifier>(), new []{expectedEffect}).GetSut();

            Assert.ThrowsAsync<ArgumentException>(async () => await sut.UpdateModifier(expectedEffect.Id, Guid.Empty, new ModifierRequest()));
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