#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AdopetAPI.csproj", "."]
RUN dotnet restore "./AdopetAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AdopetAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdopetAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdopetAPI.dll"]