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


import { CharacterSummaryResponse } from './character-summary-response';

/**
 * 
 * @export
 * @interface CharacterSummaryResponsePageResponse
 */
export interface CharacterSummaryResponsePageResponse {
    /**
     * 
     * @type {number}
     * @memberof CharacterSummaryResponsePageResponse
     */
    pageIndex: number;
    /**
     * 
     * @type {number}
     * @memberof CharacterSummaryResponsePageResponse
     */
    pageSize: number;
    /**
     * 
     * @type {number}
     * @memberof CharacterSummaryResponsePageResponse
     */
    totalCount: number;
    /**
     * 
     * @type {number}
     * @memberof CharacterSummaryResponsePageResponse
     */
    totalPages: number;
    /**
     * 
     * @type {boolean}
     * @memberof CharacterSummaryResponsePageResponse
     */
    hasPreviousPage: boolean;
    /**
     * 
     * @type {boolean}
     * @memberof CharacterSummaryResponsePageResponse
     */
    hasNextPage: boolean;
    /**
     * 
     * @type {Array<CharacterSummaryResponse>}
     * @memberof CharacterSummaryResponsePageResponse
     */
    items: Array<CharacterSummaryResponse> | null;
}


