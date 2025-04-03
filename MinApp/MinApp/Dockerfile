FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MinApp/MinApp.csproj", "MinApp/"]
RUN dotnet restore "MinApp/MinApp.csproj"
COPY . .
WORKDIR "/src/MinApp"
RUN dotnet build "MinApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MinApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /src/MinApp
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinApp.dll"]
