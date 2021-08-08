#!/bin/bash

dotnet tool restore
dotnet build
dotnet swagger tofile --output ./openapi.json ./bin/Debug/net5.0/OatMilk.Backend.Api.dll v1
npx @openapitools/openapi-generator-cli generate
read -p "[Press enter to continue...]"