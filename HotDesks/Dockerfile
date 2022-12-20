FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HotDesks/HotDesks.csproj", "HotDesks/"]
RUN dotnet restore "HotDesks/HotDesks.csproj"
COPY . .
WORKDIR "/src/HotDesks"
RUN dotnet build "HotDesks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HotDesks.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotDesks.dll"]
