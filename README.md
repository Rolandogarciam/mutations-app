[![codecov](https://codecov.io/gh/Rolandogarciam/mutations-app/branch/main/graph/badge.svg?token=6G51TC57VJ)](https://codecov.io/gh/Rolandogarciam/mutations-app)

# How to Install and Run the Project
## Requirements 
  - Dotnet SDK 6
  - Azure Cosmos DB (Table API)
  - Docker

## Setup .NET
Select your operating system  https://docs.microsoft.com/dotnet/core/install
Download and install the SDK https://dotnet.microsoft.com/download/dotnet

### Restore Dependencies
`dotnet restore`

### Build Solution
`dotnet build --no-restore`

### Run Project

#### Linux

`export COSMOS_CONNECTION_STRING = "<connection-string>"`
`export ASPNETCORE_URLS="http://localhost:8080;https://localhost:8443"`

#### Windows

`set COSMOS_CONNECTION_STRING = "<connection-string>"`
`set ASPNETCORE_URLS="http://localhost:8080;https://localhost:8443"`

`dotnet run --project api/meli-mutations/meli-mutations.csproj --no-launch-profile`

#### lauchProfile.json

`dotnet run --project api/meli-mutations/meli-mutations.csproj --launch-profile meli_mutations`

## Endpoints 

Healtcheck (GET): https://meli.code2.me/dna/healthcheck

Mutant (POST): https://meli.code2.me/dna/mutant

Stats (GET): https://meli.code2.me/dna/stats
