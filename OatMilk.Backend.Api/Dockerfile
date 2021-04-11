#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OatMilk.Backend.Api/OatMilk.Backend.Api.csproj", "OatMilk.Backend.Api/"]
# RUN dotnet restore "OatMilk.Backend.Api.csproj"
COPY . . 
WORKDIR "/src/OatMilk.Backend.Api"
RUN dotnet build "OatMilk.Backend.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OatMilk.Backend.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OatMilk.Backend.Api.dll"]