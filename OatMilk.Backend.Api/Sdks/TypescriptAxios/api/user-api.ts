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
import { ErrorResponse } from '../models';
// @ts-ignore
import { UserAuthTokenResponse } from '../models';
// @ts-ignore
import { UserLoginRequest } from '../models';
// @ts-ignore
import { UserRequest } from '../models';
// @ts-ignore
import { UserResponse } from '../models';
/**
 * UserApi - axios parameter creator
 * @export
 */
export const UserApiAxiosParamCreator = function (configuration?: Configuration) {
    return {
        /**
         * 
         * @summary Login with existing user credentials.
         * @param {UserLoginRequest} [userLoginRequest] Existing user credentials
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        userLoginPost: async (userLoginRequest?: UserLoginRequest, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/User/login`;
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
            localVarRequestOptions.data = serializeDataIfNeeded(userLoginRequest, localVarRequestOptions, configuration)

            return {
                url: toPathString(localVarUrlObj),
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary Get this user\'s profile.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        userProfileGet: async (options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/User/profile`;
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
         * @summary Register with new user credentials.
         * @param {UserRequest} [userRequest] New user credentials.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        userRegisterPost: async (userRequest?: UserRequest, options: any = {}): Promise<RequestArgs> => {
            const localVarPath = `/User/register`;
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
            localVarRequestOptions.data = serializeDataIfNeeded(userRequest, localVarRequestOptions, configuration)

            return {
                url: toPathString(localVarUrlObj),
                options: localVarRequestOptions,
            };
        },
    }
};

/**
 * UserApi - functional programming interface
 * @export
 */
export const UserApiFp = function(configuration?: Configuration) {
    const localVarAxiosParamCreator = UserApiAxiosParamCreator(configuration)
    return {
        /**
         * 
         * @summary Login with existing user credentials.
         * @param {UserLoginRequest} [userLoginRequest] Existing user credentials
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async userLoginPost(userLoginRequest?: UserLoginRequest, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<UserAuthTokenResponse>> {
            const localVarAxiosArgs = await localVarAxiosParamCreator.userLoginPost(userLoginRequest, options);
            return createRequestFunction(localVarAxiosArgs, globalAxios, BASE_PATH, configuration);
        },
        /**
         * 
         * @summary Get this user\'s profile.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async userProfileGet(options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<UserResponse>> {
            const localVarAxiosArgs = await localVarAxiosParamCreator.userProfileGet(options);
            return createRequestFunction(localVarAxiosArgs, globalAxios, BASE_PATH, configuration);
        },
        /**
         * 
         * @summary Register with new user credentials.
         * @param {UserRequest} [userRequest] New user credentials.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async userRegisterPost(userRequest?: UserRequest, options?: any): Promise<(axios?: AxiosInstance, basePath?: string) => AxiosPromise<UserAuthTokenResponse>> {
            const localVarAxiosArgs = await localVarAxiosParamCreator.userRegisterPost(userRequest, options);
            return createRequestFunction(localVarAxiosArgs, globalAxios, BASE_PATH, configuration);
        },
    }
};

/**
 * UserApi - factory interface
 * @export
 */
export const UserApiFactory = function (configuration?: Configuration, basePath?: string, axios?: AxiosInstance) {
    const localVarFp = UserApiFp(configuration)
    return {
        /**
         * 
         * @summary Login with existing user credentials.
         * @param {UserLoginRequest} [userLoginRequest] Existing user credentials
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        userLoginPost(userLoginRequest?: UserLoginRequest, options?: any): AxiosPromise<UserAuthTokenResponse> {
            return localVarFp.userLoginPost(userLoginRequest, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary Get this user\'s profile.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        userProfileGet(options?: any): AxiosPromise<UserResponse> {
            return localVarFp.userProfileGet(options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary Register with new user credentials.
         * @param {UserRequest} [userRequest] New user credentials.
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        userRegisterPost(userRequest?: UserRequest, options?: any): AxiosPromise<UserAuthTokenResponse> {
            return localVarFp.userRegisterPost(userRequest, options).then((request) => request(axios, basePath));
        },
    };
};

/**
 * UserApi - object-oriented interface
 * @export
 * @class UserApi
 * @extends {BaseAPI}
 */
export class UserApi extends BaseAPI {
    /**
     * 
     * @summary Login with existing user credentials.
     * @param {UserLoginRequest} [userLoginRequest] Existing user credentials
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof UserApi
     */
    public userLoginPost(userLoginRequest?: UserLoginRequest, options?: any) {
        return UserApiFp(this.configuration).userLoginPost(userLoginRequest, options).then((request) => request(this.axios, this.basePath));
    }

    /**
     * 
     * @summary Get this user\'s profile.
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof UserApi
     */
    public userProfileGet(options?: any) {
        return UserApiFp(this.configuration).userProfileGet(options).then((request) => request(this.axios, this.basePath));
    }

    /**
     * 
     * @summary Register with new user credentials.
     * @param {UserRequest} [userRequest] New user credentials.
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof UserApi
     */
    public userRegisterPost(userRequest?: UserRequest, options?: any) {
        return UserApiFp(this.configuration).userRegisterPost(userRequest, options).then((request) => request(this.axios, this.basePath));
    }
}