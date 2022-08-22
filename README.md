
[![codecov](https://codecov.io/gh/Rolandogarciam/mutations-app/branch/main/graph/badge.svg?token=6G51TC57VJ)](https://codecov.io/gh/Rolandogarciam/mutations-app)

## Requirements 
  - Dotnet SDK 6
  - Azure Cosmos DB (Table API)
  - Docker

## Setup .NET

 - Select your operating system  https://docs.microsoft.com/dotnet/core/install
- Download and install the SDK https://dotnet.microsoft.com/download/dotnet

### Restore Dependencies
`dotnet restore`

### Build Solution
`dotnet build --no-restore`

### Run Project
`dotnet run --project api/meli-mutations/meli-mutations.csproj --no-launch-profile`

#### Linux
```
export COSMOS_CONNECTION_STRING = "<connection-string>"
export ASPNETCORE_URLS="http://localhost:8080;https://localhost:8443"
```
#### Windows

```
set COSMOS_CONNECTION_STRING = "<connection-string>"
set ASPNETCORE_URLS="http://localhost:8080;https://localhost:8443"
```

#### lauchProfile.json

`dotnet run --project api/meli-mutations/meli-mutations.csproj --launch-profile meli_mutations`

### Run Test

`dotnet test`

### Docker

```
docker build . -f docker/Dockerfile
docker run --publish 80:80 <image>
```

## Endpoints 

Healtcheck (GET): https://meli.code2.me/dna/healthcheck

Mutant (POST): https://meli.code2.me/dna/mutant

Stats (GET): https://meli.code2.me/dna/stats

## Architecture
![image](https://firebasestorage.googleapis.com/v0/b/rolandogarciam-3b3a2.appspot.com/o/mutant-app-architecture.png?alt=media&token=48b0ce79-a3ae-4f6d-b2b3-ea43a33f1f5c) 
