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
 * JWT Token DTO.  Passed as a response when they login or register.   Will contain the JWT token that is used to authenticate with the backend.
 * @export
 * @interface UserAuthTokenResponse
 */
export interface UserAuthTokenResponse {
    /**
     * 
     * @type {string}
     * @memberof UserAuthTokenResponse
     */
    authToken?: string | null;
}

