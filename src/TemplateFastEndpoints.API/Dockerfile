FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/TemplateFastEndpoints.API/TemplateFastEndpoints.API.csproj", "TemplateFastEndpoints.API/"]
RUN dotnet restore "src/TemplateFastEndpoints.API/TemplateFastEndpoints.API.csproj"
COPY . .
WORKDIR "/src/TemplateFastEndpoints.API"
RUN dotnet build "TemplateFastEndpoints.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TemplateFastEndpoints.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TemplateFastEndpoints.API.dll"]
