# Techstore API
A basic server for an ecommerce site using using ASP.NET Core Web API

## Technologies used:
* ASP.NET Core 2.2
* Postgresql

## Screenshot
![Screenshot #1](https://i.imgur.com/ErF8hWE.png)

## Usage
After cloning the project, modify the value of DatabaseConfig in appsettings.json to your postgresql credentials
```
  "DatabaseConfig": {
    "PostgresSQL": "Server=192.168.99.100;Port=5432;Database=dbName;User Id=yourUserId;Password=yourPassword;"
  }
```

Then just start the server with IIS Express
