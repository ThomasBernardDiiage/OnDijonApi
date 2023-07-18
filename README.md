# Introduction

Ce projet est une application Web API ASP.NET Core. Il utilise Entity Framework Core pour la gestion des données en utilisant PostgreSQL comme base de données.

# Configurations

## appsettings.json

Pour utiliser les variables d'environnements avec ce projet, vous devez créer un fichier `appsettings.json` dans le dossier `OnDijon`.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",

  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Initial Catalog=OnDijon;Persist Security Info=False;User ID=sa;Password=your-strong-password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
  }
}
```

## OnDijonDbContextFactory

Pour utiliser Entity Framework Core avec ce projet, vous devez créer un fichier `OnDijonDbContextFactory` dans le dossier `DataAccess`. Ce fichier doit implémenter `IDesignTimeDbContextFactory<OnDijonDbContext>` pour permettre l'exécution de commandes de migration Entity Framework Core.

```csharp
using Microsoft.EntityFrameworkCore.Design;

namespace OnDijon.DataAccess
{
    internal class OnDijonDbContextFactory : IDesignTimeDbContextFactory<OnDijonDbContext>
    {
        public OnDijonDbContext CreateDbContext(string[] args)
        {
            const string connection = "Server=localhost,1433;Initial Catalog=OnDijon;Persist Security Info=False;User ID=sa;Password=your-strong-password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

            return new OnDijonDbContext(connection);
        }
    }

}
```


## Lancer les migrations

Pour executer les migrations il faut utiliser une commande `dotnet ef`. Si vous ne possedez pas l'outil ef pour dotnet vous pouvez l'installer en utilisant cette commande :
```shell
dotnet tool install --global dotnet-ef --version 6.0.11
````

Après installation de l'outil ef vous pouvez executer cette commande pour effectuer les migrations : 

```shell
dotnet ef database update
```

Cela va créer les différentes tables et changement sur la base de données.

## Créer une migration

Pour créer une migration il faut tout d'abord ajouter une configuration, cela représente notre classe au sein de notre base de données.
Une fois cette configuration ajoutée il faut éxécuter cette commande afin de créer une migration : 

```shell
dotnet ef migrations add your_migration_name
```

Pour plus d'informations se référer à la documentation officielle de Microsoft : https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli


