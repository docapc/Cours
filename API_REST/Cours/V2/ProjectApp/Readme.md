# Solution exemple simple

## Projets

**ProjetApp**

API avec méthode CRUD sur des projets.

**ConsoleAppProject**

Application console qui envoie une requete sur l'API ProjetApp et traite le résultat de la requête.  

## Base EF

Prérequis : créer base de données (ici projectdatabase).

Chaine de connexion à la base de donnée : appsettings.Development.json

Pour ajouter des migrations à votre base :
- Ouvrir la console du gestionnaire de package sur Visual Studio
- Mettre comme projet par défaut votre projet d'API
- Ajouter une migration : `EntityFrameworkCore\add-migration` 
- Appliquer une migration sur votre base : `EntityFrameworkCore\update-database` 