# DotNet Todo API

A CRUD API for a TODO sample app

## Local development

You must add dotnet secrets to store the MongoDB connection string. Example here;

```
dotnet user-secrets init  

dotnet user-secrets set "TodoDatabaseSettings:ConnectionString" "[example-mongo-connection-string-here]"
```
