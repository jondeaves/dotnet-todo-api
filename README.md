# DotNet Todo API

A CRUD API for a TODO sample app

## Local development

You must add dotnet secrets to store the MongoDB connection string. Example here;

```
dotnet user-secrets init

dotnet user-secrets set "TodoDatabaseSettings:ConnectionString" "[example-mongo-connection-string-here]"
```

## Deploying

Provide the following environment variables

```
TodoDatabaseSettings:ConnectionString=[example-mongo-connection-string-here] # Connection string to a monogodb collection
PORT=5002 # The port our application will listen on
```