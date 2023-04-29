FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RegularScript.Helper/RegularScript.Helper.csproj", "RegularScript.Helper/"]
RUN dotnet restore "RegularScript.Helper/RegularScript.Helper.csproj"
COPY . .
WORKDIR "/src/RegularScript.Helper"
RUN dotnet build "RegularScript.Helper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RegularScript.Helper.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RegularScript.Helper.dll"]
