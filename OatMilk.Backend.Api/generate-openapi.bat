dotnet tool restore
dotnet build
dotnet swagger tofile --output ./backend.json ./bin/Debug/net5.0/OatMilk.Backend.Api.dll v1
pause