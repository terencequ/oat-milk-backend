#!/bin/bash

dotnet tool restore
dotnet swagger tofile --output ./openapi.json ./bin/Debug/net5.0/OatMilk.Backend.Api.dll v1
npx @openapitools/openapi-generator-cli generate

npm --prefix ./Sdks/TypescriptAxios version patch
read -p "[Press enter to continue...]"