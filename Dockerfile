# Cet index est utilisé lors de l’exécution à partir de VS en mode rapide (par défaut pour la configuration de débogage)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Cette phase est utilisée pour générer le projet de service
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copier le fichier .csproj depuis le sous-répertoire "TenisStat.Backend"
COPY TenisStat.Backend/TenisStat.Backend.csproj TenisStat.Backend/

# Restaurer les packages
RUN dotnet restore "./TenisStat.Backend/TenisStat.Backend.csproj"

# Copier tout le contenu du projet
COPY . .

# Définir le répertoire de travail dans lequel le projet sera construit
WORKDIR "/src/TenisStat.Backend"

# Construire le projet en mode Release
RUN dotnet build "./TenisStat.Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publier le projet
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TenisStat.Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Cette phase est utilisée en production ou lors de l’exécution à partir de VS en mode normal (par défaut quand la configuration de débogage n’est pas utilisée)
FROM base AS final
WORKDIR /app

# Copier les fichiers publiés depuis la phase précédente
COPY --from=publish /app/publish .

# Entrypoint du conteneur
ENTRYPOINT ["dotnet", "TenisStat.Backend.dll"]
