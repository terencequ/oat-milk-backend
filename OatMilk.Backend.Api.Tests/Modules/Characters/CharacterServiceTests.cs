using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Characters.Domain;
using OatMilk.Backend.Api.Tests.TestingHelpers;

namespace OatMilk.Backend.Api.Tests.Modules.Characters
{
    public class CharacterServiceTests
    {
        private class Fixture : UserEntityRepositoryFixture<Character>
        {
            public Fixture(params Character[] characters) : base(ObjectId.GenerateNewId(), characters) { }
            
            public CharacterService GetSut()
            {
                return new(MockUserRepository.Object, Mapper);
            }
        }
        
        #region Create
        
        #endregion
    }
}