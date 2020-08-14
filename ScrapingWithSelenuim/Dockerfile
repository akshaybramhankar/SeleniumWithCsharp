FROM masteroleary/selenium-dotnetcore2.2-linux:v2 AS base

WORKDIR /app

EXPOSE 80

EXPOSE 443

FROM masteroleary/selenium-dotnetcore2.2-linux:v2 AS build 

WORKDIR /src

COPY ["ScrapingWithSelenuim.csproj", ""]

RUN dotnet restore "ScrapingWithSelenuim.csproj"

COPY . .

WORKDIR "/src/"

RUN dotnet build "ScrapingWithSelenuim.csproj" -c Prod -o /app

FROM build AS publish

RUN dotnet publish "ScrapingWithSelenuim.csproj" -c Prod -o /app

FROM base AS final

WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "ScrapingWithSelenuim.dll"]