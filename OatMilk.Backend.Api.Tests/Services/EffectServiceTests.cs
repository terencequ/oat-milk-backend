using System;
using System.Linq;
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
                return new(MockRepository.Object, _mockModifierRepository.Object, Mapper);
            }
        }

        #region CreateAndAssignModifier
        
        #endregion
        
        #region DeleteModifier
        
        #endregion
    }
}