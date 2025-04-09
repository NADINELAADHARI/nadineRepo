# Étape 1 : Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copier les fichiers du projet
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# Étape 2 : Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "TicketCloudApi.dll"]
