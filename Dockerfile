FROM mcr.microsoft.com/dotnet/sdk:6.0 AS migrations
WORKDIR /app

ARG CON_STR
ARG DB_NAME
ENV CONNECTION_STRING=${CON_STR}

COPY . .
RUN dotnet restore --use-current-runtime
RUN dotnet tool restore
RUN dotnet ef migrations add Initial -p ./Persistence/ -s ./Api/
RUN dotnet ef database update -p ./Persistence/ -s ./Api/

RUN apt-get -y update
RUN apt-get -y upgrade
RUN apt-get install -y sqlite3
RUN sqlite3 ${DB_NAME} ".read db_data.sql"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY *.sln .
COPY Api/*.csproj ./Api/
COPY Aplication/*.csproj ./Aplication/
COPY Domain/*.csproj ./Domain/
COPY Persistence/*.csproj ./Persistence/
RUN dotnet restore --use-current-runtime

COPY . .
RUN dotnet publish -c Release -o /app --use-current-runtime --self-contained false --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
ARG DB_NAME
COPY --from=build /app .
COPY --from=migrations /app/${DB_NAME} .
CMD export CONNECTION_STRING="Filename=/app/games_api.db" && dotnet Api.dll