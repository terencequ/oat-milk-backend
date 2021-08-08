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


import { CharacterResponse } from './character-response';

/**
 * 
 * @export
 * @interface CharacterResponsePageResponse
 */
export interface CharacterResponsePageResponse {
    /**
     * 
     * @type {number}
     * @memberof CharacterResponsePageResponse
     */
    pageIndex?: number;
    /**
     * 
     * @type {number}
     * @memberof CharacterResponsePageResponse
     */
    pageSize?: number;
    /**
     * 
     * @type {number}
     * @memberof CharacterResponsePageResponse
     */
    totalCount?: number;
    /**
     * 
     * @type {number}
     * @memberof CharacterResponsePageResponse
     */
    totalPages?: number;
    /**
     * 
     * @type {boolean}
     * @memberof CharacterResponsePageResponse
     */
    hasPreviousPage?: boolean;
    /**
     * 
     * @type {boolean}
     * @memberof CharacterResponsePageResponse
     */
    hasNextPage?: boolean;
    /**
     * 
     * @type {Array<CharacterResponse>}
     * @memberof CharacterResponsePageResponse
     */
    items?: Array<CharacterResponse> | null;
}


