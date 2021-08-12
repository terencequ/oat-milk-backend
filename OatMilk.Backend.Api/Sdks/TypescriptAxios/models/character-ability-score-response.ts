/* tslint:disable */
/* eslint-disable */
/**
 * OatMilk.Backend.Api
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


import { CharacterAbilityScoreProficiencyResponse } from './character-ability-score-proficiency-response';

/**
 * 
 * @export
 * @interface CharacterAbilityScoreResponse
 */
export interface CharacterAbilityScoreResponse {
    /**
     * 
     * @type {string}
     * @memberof CharacterAbilityScoreResponse
     */
    id: string;
    /**
     * 
     * @type {string}
     * @memberof CharacterAbilityScoreResponse
     */
    name: string;
    /**
     * 
     * @type {number}
     * @memberof CharacterAbilityScoreResponse
     */
    value: number;
    /**
     * 
     * @type {boolean}
     * @memberof CharacterAbilityScoreResponse
     */
    proficient: boolean;
    /**
     * 
     * @type {boolean}
     * @memberof CharacterAbilityScoreResponse
     */
    expertise: boolean;
    /**
     * 
     * @type {Array<CharacterAbilityScoreProficiencyResponse>}
     * @memberof CharacterAbilityScoreResponse
     */
    proficiencies: Array<CharacterAbilityScoreProficiencyResponse>;
}

