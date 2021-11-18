FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build --no-restore -c Release -o /app

FROM build as publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base as final
WORKDIR /app
COPY --from=publish /app .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet LighthouseAPI.dll