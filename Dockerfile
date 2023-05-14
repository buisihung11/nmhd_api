# Use an official .NET Core 5 runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 as base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
COPY . ./src
WORKDIR /src
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM base AS final
WORKDIR /app
RUN ls
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "NuocMamHongDuc_Web_App.dll"]
