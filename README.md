# Course Scheduler

[![Build Status](https://github.com/Sundy0828/CourseSchedule/actions/workflows/main.yml/badge.svg)](https://github.com/Sundy0828/CourseSchedule/actions/workflows/main.yml)

## Getting Started

## Create environment file

Create a .env file with the contents below.

```
ASPNETCORE_ENVIRONMENT=Development
ASPNETCORE_URLS=http://+:80
ConnectionStrings__DefaultConnection="host=db;Port=26257;database=db;user id=root;Include Error Detail=true"
SEED_INSERT_DATA=1
```

## Build

Requires dotnet and docker installed.

```shell
docker-compose up
```

Docker-compose will run a build on the project and spin up several containers.

## Database

Database access and migrations are controlled through EF Core. The DbContext class is the handler for all database calls through the use of DBset objects. The connection string is supplided in the appsettings.json file, and loaded into the program class for the web service. This is a code first approach so your models will be defined in code and EF will handle generation of table scripts. In order to create new tables and relations, you can define new models in the dbmodel class and include them in the db context class. This is a very basic impliementation, more control can be exercised through attribute tags.


Set Package Manager Console to Core project and start up project to API. Run "Add-Migration InitialCreate".

When making additional updates after the first run, run "Udate-Database" in ht e VS Package Manager Console.

### Common Database Issues

Try running to commands.

```
./cockroach sql --insecure
drop database "db" cascade;
```