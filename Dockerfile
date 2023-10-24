# Usa a imagem oficial do SDK do .NET como base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PokerPlanningDev/PokerPlanningDev.csproj", "PokerPlanningDev/"]
COPY ["Shared/Shared.csproj", "Shared/"]

RUN dotnet restore "PokerPlanningDev/PokerPlanningDev.csproj"

COPY . .
WORKDIR "/src/PokerPlanningDev"
RUN dotnet build "PokerPlanningDev.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PokerPlanningDev.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PokerPlanningDev.dll"]