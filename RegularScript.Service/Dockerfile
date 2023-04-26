FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RegularScript.Service/RegularScript.Service.csproj", "RegularScript.Service/"]
RUN dotnet restore "RegularScript.Service/RegularScript.Service.csproj"
COPY . .
WORKDIR "/src/RegularScript.Service"
RUN dotnet build "RegularScript.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RegularScript.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RegularScript.Service.dll"]
