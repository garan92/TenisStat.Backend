# TenisStat API

Bienvenue dans **TenisStat API**. Cette API fournit des statistiques sur les joueurs de tennis, y compris les classements et les statistiques globales.


## Lancement de l'application TenisStat

Ce document fournit une procédure étape par étape pour lancer l'application **TenisStat**. 

## Prérequis

Avant de commencer, assurez-vous que vous avez les éléments suivants installés :

- [**.NET SDK 6.0**](https://dotnet.microsoft.com/download/dotnet/6.0)
- Un client HTTP pour tester l'API (tel que [Postman](https://www.postman.com/) ou [curl](https://curl.se/)).
- Un éditeur de code (tel que [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)) est recommandé pour le développement.

## Étapes pour lancer l'application

### 1. Cloner le dépôt

Commencez par cloner le dépôt de l'application sur votre machine locale.

```bash
git clone <https://github.com/garan92/TenisStat.Backend.git>
cd TenisStat.backend
dotnet restore
dotnet run

```
## Points de terminaison de l'API

### 1. Obtenir la liste des joueuers du mieux classé au moins bon

- **URL** : `/api/TenisStat/GetPlayersRanking`
- **Méthode** : `GET`
- **Description** : Récupère la liste des joueuers avec leur nom et leur classement.
- **Réponse** :
  - **200 OK** : Une liste de `PlayerRanking`.
  - **500 Internal Server Error** : En cas d'erreur lors de la récupération des données.

#### Exemple de requête

```http
GET /api/TenisStat/GetPlayersRanking HTTP/1.1
Host: localhost:7096
```
### 1. Obtenir les informations d'un joueur

- **URL** : `/api/TenisStat/GetPlayerById/{id}`
- **Méthode** : `GET`
- **Description** : Récupère les informations du joueur selon son id.
- **Réponse** :
  - **200 OK** : `Player`.
  - **500 Internal Server Error** : Player with ID `id` not found.

#### Exemple de requête

```http
GET /api/TenisStat/GetPlayersRanking/{id} HTTP/1.1
Host: localhost:7096
```
### 3. Obtenir les statistiques spécifiques

- **URL** : `/api/TenisStat/GetGlobalStatistics`
- **Méthode** : `GET`
- **Description** : Récupère les informations suivantes:
    - Pays qui a le plus grand ratio de parties gagnées
    - IMC moyen de tous les joueurs
    - La médiane de la taille des joueurs 
- **Réponse** :
  - **200 OK** : `GlobalStatistics`.
  - **500 Internal Server Error** : En cas d'erreur lors de la récupération des données.

#### Exemple de requête

```http
GET /api/TenisStat/GetGlobalStatistics HTTP/1.1
Host: localhost:7096
```
