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
 * @interface CharacterAttributeRequest
 */
export interface CharacterAttributeRequest {
    /**
     * 
     * @type {string}
     * @memberof CharacterAttributeRequest
     */
    id: string;
    /**
     * 
     * @type {string}
     * @memberof CharacterAttributeRequest
     */
    name?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CharacterAttributeRequest
     */
    currentValue?: number;
    /**
     * 
     * @type {number}
     * @memberof CharacterAttributeRequest
     */
    defaultValue?: number;
}


