FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Edule.Api/Edule.Api.csproj", "Edule.Api/"]
RUN dotnet restore "Edule.Api/Edule.Api.csproj"
COPY . .
WORKDIR "/src/Edule.Api"
RUN dotnet build "Edule.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Edule.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Edule.Api.dll"]
