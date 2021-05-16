using System;
using System.Threading.Tasks;
using AutoMapper;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface ICharacterService :  IUserEntityService<CharacterRequest, CharacterResponse>
    {
        /// <summary>
        /// Create a blank set of attributes for the character.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Updated Character.</returns>
        /// <exception cref="ArgumentException"></exception>
        Task<CharacterResponse> SetupAttributes(Guid id);

        /// <summary>
        /// Apply an ability's effects to a character.
        /// </summary>
        /// <returns>Updated character.</returns>
        Task<CharacterResponse> ApplyAbilityToCharacter(Guid id, Guid abilityId);
    }
}