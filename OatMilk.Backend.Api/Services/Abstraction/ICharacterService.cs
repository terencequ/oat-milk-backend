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
        Task<CharacterResponse> ResetCharacter(Guid id);

        /// <summary>
        /// Apply an ability's effects to a character.
        /// </summary>
        /// <returns>Updated character.</returns>
        Task<CharacterResponse> ApplyAbilityAsTarget(Guid id, Guid abilityId);

        /// <summary>
        /// Edit an attribute on the character.
        /// </summary>
        /// <param name="id">Id of the character</param>
        /// <param name="attributeType">Type of attribute</param>
        /// <param name="attributeRequest">Updated attribute properties</param>
        /// <returns></returns>
        Task<AttributeResponse> EditAttribute(Guid id, string attributeType, AttributeRequest attributeRequest);
    }
}