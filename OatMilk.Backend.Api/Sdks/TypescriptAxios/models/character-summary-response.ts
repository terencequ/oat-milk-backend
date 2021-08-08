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



/**
 * 
 * @export
 * @interface CharacterSummaryResponse
 */
export interface CharacterSummaryResponse {
    /**
     * 
     * @type {string}
     * @memberof CharacterSummaryResponse
     */
    id: string;
    /**
     * 
     * @type {string}
     * @memberof CharacterSummaryResponse
     */
    identifier: string;
    /**
     * 
     * @type {string}
     * @memberof CharacterSummaryResponse
     */
    createdDateTimeUtc?: string;
    /**
     * 
     * @type {string}
     * @memberof CharacterSummaryResponse
     */
    updatedDateTimeUtc?: string;
    /**
     * 
     * @type {string}
     * @memberof CharacterSummaryResponse
     */
    classes?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CharacterSummaryResponse
     */
    name: string;
    /**
     * 
     * @type {number}
     * @memberof CharacterSummaryResponse
     */
    level?: number;
    /**
     * 
     * @type {number}
     * @memberof CharacterSummaryResponse
     */
    experience?: number;
    /**
     * 
     * @type {number}
     * @memberof CharacterSummaryResponse
     */
    previousLevelExperienceRequirement?: number;
    /**
     * 
     * @type {number}
     * @memberof CharacterSummaryResponse
     */
    nextLevelExperienceRequirement?: number;
    /**
     * 
     * @type {boolean}
     * @memberof CharacterSummaryResponse
     */
    isAlive?: boolean;
}


