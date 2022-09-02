FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80:8081

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Confitec.Technical.Test.Api/Confitec.Technical.Test.Api.csproj", "Confitec.Technical.Test.Api/"]
RUN dotnet restore "Confitec.Technical.Test.Api/Confitec.Technical.Test.Api.csproj"
COPY . .
WORKDIR "/src/Confitec.Technical.Test.Api"
RUN dotnet build "Confitec.Technical.Test.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Confitec.Technical.Test.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Confitec.Technical.Test.Api.dll"]