# Étape 1 : build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copier les fichiers csproj et restaurer les dépendances
COPY TicketCloudAPI/*.csproj ./TicketCloudAPI/
RUN dotnet restore TicketCloudAPI/TicketCloudAPI.csproj

# Copier tout le reste et compiler
COPY . . 
WORKDIR /app/TicketCloudAPI
RUN dotnet publish -c Release -o out

# Étape 2 : runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/TicketCloudAPI/out .

ENTRYPOINT ["dotnet", "TicketCloudAPI.dll"]
