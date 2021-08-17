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


import globalAxios, { AxiosPromise, AxiosInstance } from 'axios';
import { Configuration } from '../configuration';
// Some imports not used depending on template conditions
// @ts-ignore
import { DUMMY_BASE_URL, assertParamExists, setApiKeyToObject, setBasicAuthToObject, setBearerAuthToObject, setOAuthToObject, setSearchParams, serializeDataIfNeeded, toPathString, createRequestFunction } from '../common';
// @ts-ignore
import { BASE_PATH, COLLECTION_FORMATS, RequestArgs, BaseAPI, RequiredError } from '../base';
// @ts-ignore
import { CharacterRequest } from '../models';
// @ts-ignore
import { CharacterResponse } from '../models';
// @ts-ignore
import { CharacterResponsePageResponse } from '../models';
// @ts-ignore
import { ErrorResponse } from '../models';
// @ts-ignore
import { UNKNOWN_BASE_TYPE } from '../models';
/**
 * CharacterApi - axios parameter creator
 * @export
 */
export const CharacterApiAxiosParamCreator = function (configuration?: Configuration) {
    return {
        /**
         * 
         * @summary Get a paginated, filtered and sorted list of all existing characters, with all details.
         * @param {string} [searchByName] 
         * @param {string} [sortColumnName] Name of the column to sort by.
         * @param {boolean} [sortAscending] Whether or not to sort in ascending order.
         * @param {number} [pageIndex] 
         * @param {number} [pageSize] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        characterFullGet: async (searchByName?: string, sortColumnName?: string, sortAscending?: boolean, pageIndex?: number, pageSize?: number, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/Character/full`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, DUMMY_BASE_URL);
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }

            const localVarRequestOptions = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            if (searchByName !== undefined) {
                localVarQueryParameter['SearchByName'] = searchByName;
            }

            if (sortColumnName !== undefined) {
                localVarQueryParameter['SortColumnName'] = sortColumnName;
            }

            if (sortAscending !== undefined) {
                localVarQueryParameter['SortAscending'] = sortAscending;
            }

            if (pageIndex !== undefined) {
                localVarQueryParameter['PageIndex'] = pageIndex;
            }

            if (pageSize !== undefined) {
                localVarQueryParameter['PageSize'] = pageSize;
            }


    
            setSearchParams(localVarUrlObj, localVarQueryParameter, options.query);
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: toPathString(localVarUrlObj),
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary Delete an existing character by ID.
         * @param {string} id 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        characterFullIdDelete: async (id: string, options: any = {}): Promise<RequestArgs> => {
            // verify required parameter 'id' is not null or undefined
            assertParamExists('characterFullIdDelete', 'id', id)
            const localVarPath = `/Character/full/{id}`
                .replace(`{${"id"}}`, encodeURIComponent(String(id)));
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, DUMMY_BASE_URL);
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }

            const localVarRequestOptions = { method: 'DELETE', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;


    
            setSearchParams(localVarUrlObj, localVarQueryParameter, options.query);
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: toPathString(localVarUrlObj),
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary Update an existing character by ID.
         * @param {string} id 
         * @param {UNKNOWN_BASE_TYPE} [uNKNOWNBASETYPE] Details of new character.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        characterFullIdPut: async (id: string, uNKNOWNBASETYPE?: UNKNOWN_BASE_TYPE, options: any = {}): Promise<RequestArgs> => {
            // verify required parameter 'id' is not null or undefined
            assertParamExists('characterFullIdPut', 'id', id)
            const localVarPath = `/Character/full/{id}`
                .replace(`{${"id"}}`, encodeURIComponent(String(id)));
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, DUMMY_BASE_URL);
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }

            const localVarRequestOptions = { method: 'PUT', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;


    
            localVarHeaderParameter['Content-Type'] = 'application/json';

            setSearchParams(localVarUrlObj, localVarQueryParameter, options.query);
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            localVarRequestOptions.data = serializeDataIfNeeded(uNKNOWNBASETYPE, localVarRequestOptions, configuration)

            return {
                url: toPathString(localVarUrlObj),
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary Get an existing character by its human-readable identifier.
         * @param {string} identifier Human readable unique identifier.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        characterFullIdentifierGet: async (identifier: string, options: any = {}): Promise<RequestArgs> => {
            // verify required parameter 'identifier' is not null or undefined
            assertParamExists('characterFullIdentifierGet', 'identifier', identifier)
            const localVarPath = `/Character/full/{identifier}`
                .replace(`{${"identifier"}}`, encodeURIComponent(String(identifier)));
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, DUMMY_BASE_URL);
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }

            const localVarRequestOptions = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;


    
            setSearchParams(localVarUrlObj, localVarQueryParameter, options.query);
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: toPathString(localVarUrlObj),
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary Create a character.
         * @param {UNKNOWN_BASE_TYPE} [uNKNOWNBASETYPE] Details of new character.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        characterFullPost: async (uNKNOWNBASETYPE?: UNKNOWN_BASE_TYPE, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/Character/full`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, DUMMY_BASE_URL);
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }

            const localVarRequestOptions = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;


    
            localVarHeaderParameter['Content-Type'] = 'application/json';

            setSearchParams(localVarUrlObj, localVarQueryParameter, options.query);
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            localVarRequestOptions.data = serializeDataIfNeeded(uNKNOWNBASETYPE, localVarRequestOptions, configuration)

            return {
                url: toPathString(localVarUrlObj),
                options: localVarRequestOptions,
            };
        },
    }
};

/**
 * CharacterApi - functional programming interface
 * @export
 */
export const CharacterApiFp = function(configuration?: Configuration) {
    const localVarAxiosParamCreator = CharacterApiAxiosParamCreator(configuration)
    return {
        /**
         * 
         * @summary Get a paginated, filtered and sorted list of all existing characters, with all details.
         * @param {string} [searchByName] 
         * @param {string} [sortColumnName] Name of the column to sort by.
         * @param {boolean} [sortAscending] Whether or not to sort in ascending order.
         * @param {number} [pageIndex] 
         * @param {number} [pageSize] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async characterFullGet(searchByName?: string, sortColumnName?: string, sortAscending?: boolean, pageIndex?: number, pageSize?: number, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<CharacterResponsePageResponse>> {
            const localVarAxiosArgs = await localVarAxiosParamCreator.characterFullGet(searchByName, sortColumnName, sortAscending, pageIndex, pageSize, options);
            return createRequestFunction(localVarAxiosArgs, globalAxios, BASE_PATH, configuration);
        },
        /**
         * 
         * @summary Delete an existing character by ID.
         * @param {string} id 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async characterFullIdDelete(id: string, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<void>> {
            const localVarAxiosArgs = await localVarAxiosParamCreator.characterFullIdDelete(id, options);
            return createRequestFunction(localVarAxiosArgs, globalAxios, BASE_PATH, configuration);
        },
        /**
         * 
         * @summary Update an existing character by ID.
         * @param {string} id 
         * @param {UNKNOWN_BASE_TYPE} [uNKNOWNBASETYPE] Details of new character.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async characterFullIdPut(id: string, uNKNOWNBASETYPE?: UNKNOWN_BASE_TYPE, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<CharacterResponse>> {
            const localVarAxiosArgs = await localVarAxiosParamCreator.characterFullIdPut(id, uNKNOWNBASETYPE, options);
            return createRequestFunction(localVarAxiosArgs, globalAxios, BASE_PATH, configuration);
        },
        /**
         * 
         * @summary Get an existing character by its human-readable identifier.
         * @param {string} identifier Human readable unique identifier.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async characterFullIdentifierGet(identifier: string, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<CharacterResponse>> {
            const localVarAxiosArgs = await localVarAxiosParamCreator.characterFullIdentifierGet(identifier, options);
            return createRequestFunction(localVarAxiosArgs, globalAxios, BASE_PATH, configuration);
        },
        /**
         * 
         * @summary Create a character.
         * @param {UNKNOWN_BASE_TYPE} [uNKNOWNBASETYPE] Details of new character.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async characterFullPost(uNKNOWNBASETYPE?: UNKNOWN_BASE_TYPE, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<CharacterResponse>> {
            const localVarAxiosArgs = await localVarAxiosParamCreator.characterFullPost(uNKNOWNBASETYPE, options);
            return createRequestFunction(localVarAxiosArgs, globalAxios, BASE_PATH, configuration);
        },
    }
};

/**
 * CharacterApi - factory interface
 * @export
 */
export const CharacterApiFactory = function (configuration?: Configuration, basePath?: string, axios?: AxiosInstance) {
    const localVarFp = CharacterApiFp(configuration)
    return {
        /**
         * 
         * @summary Get a paginated, filtered and sorted list of all existing characters, with all details.
         * @param {string} [searchByName] 
         * @param {string} [sortColumnName] Name of the column to sort by.
         * @param {boolean} [sortAscending] Whether or not to sort in ascending order.
         * @param {number} [pageIndex] 
         * @param {number} [pageSize] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        characterFullGet(searchByName?: string, sortColumnName?: string, sortAscending?: boolean, pageIndex?: number, pageSize?: number, options?: any): AxiosPromise<CharacterResponsePageResponse> {
            return localVarFp.characterFullGet(searchByName, sortColumnName, sortAscending, pageIndex, pageSize, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary Delete an existing character by ID.
         * @param {string} id 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        characterFullIdDelete(id: string, options?: any): AxiosPromise<void> {
            return localVarFp.characterFullIdDelete(id, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary Update an existing character by ID.
         * @param {string} id 
         * @param {UNKNOWN_BASE_TYPE} [uNKNOWNBASETYPE] Details of new character.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        characterFullIdPut(id: string, uNKNOWNBASETYPE?: UNKNOWN_BASE_TYPE, options?: any): AxiosPromise<CharacterResponse> {
            return localVarFp.characterFullIdPut(id, uNKNOWNBASETYPE, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary Get an existing character by its human-readable identifier.
         * @param {string} identifier Human readable unique identifier.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        characterFullIdentifierGet(identifier: string, options?: any): AxiosPromise<CharacterResponse> {
            return localVarFp.characterFullIdentifierGet(identifier, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary Create a character.
         * @param {UNKNOWN_BASE_TYPE} [uNKNOWNBASETYPE] Details of new character.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        characterFullPost(uNKNOWNBASETYPE?: UNKNOWN_BASE_TYPE, options?: any): AxiosPromise<CharacterResponse> {
            return localVarFp.characterFullPost(uNKNOWNBASETYPE, options).then((request) => request(axios, basePath));
        },
    };
};

/**
 * CharacterApi - object-oriented interface
 * @export
 * @class CharacterApi
 * @extends {BaseAPI}
 */
export class CharacterApi extends BaseAPI {
    /**
     * 
     * @summary Get a paginated, filtered and sorted list of all existing characters, with all details.
     * @param {string} [searchByName] 
     * @param {string} [sortColumnName] Name of the column to sort by.
     * @param {boolean} [sortAscending] Whether or not to sort in ascending order.
     * @param {number} [pageIndex] 
     * @param {number} [pageSize] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof CharacterApi
     */
    public characterFullGet(searchByName?: string, sortColumnName?: string, sortAscending?: boolean, pageIndex?: number, pageSize?: number, options?: any) {
        return CharacterApiFp(this.configuration).characterFullGet(searchByName, sortColumnName, sortAscending, pageIndex, pageSize, options).then((request) => request(this.axios, this.basePath));
    }

    /**
     * 
     * @summary Delete an existing character by ID.
     * @param {string} id 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof CharacterApi
     */
    public characterFullIdDelete(id: string, options?: any) {
        return CharacterApiFp(this.configuration).characterFullIdDelete(id, options).then((request) => request(this.axios, this.basePath));
    }

    /**
     * 
     * @summary Update an existing character by ID.
     * @param {string} id 
     * @param {UNKNOWN_BASE_TYPE} [uNKNOWNBASETYPE] Details of new character.
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof CharacterApi
     */
    public characterFullIdPut(id: string, uNKNOWNBASETYPE?: UNKNOWN_BASE_TYPE, options?: any) {
        return CharacterApiFp(this.configuration).characterFullIdPut(id, uNKNOWNBASETYPE, options).then((request) => request(this.axios, this.basePath));
    }

    /**
     * 
     * @summary Get an existing character by its human-readable identifier.
     * @param {string} identifier Human readable unique identifier.
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof CharacterApi
     */
    public characterFullIdentifierGet(identifier: string, options?: any) {
        return CharacterApiFp(this.configuration).characterFullIdentifierGet(identifier, options).then((request) => request(this.axios, this.basePath));
    }

    /**
     * 
     * @summary Create a character.
     * @param {UNKNOWN_BASE_TYPE} [uNKNOWNBASETYPE] Details of new character.
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof CharacterApi
     */
    public characterFullPost(uNKNOWNBASETYPE?: UNKNOWN_BASE_TYPE, options?: any) {
        return CharacterApiFp(this.configuration).characterFullPost(uNKNOWNBASETYPE, options).then((request) => request(this.axios, this.basePath));
    }
}
