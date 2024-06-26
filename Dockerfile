FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY *.sln .
COPY Api/*.csproj ./Api/
COPY Aplication/*.csproj ./Aplication/
COPY Domain/*.csproj ./Domain/
COPY Persistence/*.csproj ./Persistence/
RUN dotnet restore --use-current-runtime

COPY . .
RUN dotnet publish -c Release -o /app --use-current-runtime --self-contained false --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Api.dll"]