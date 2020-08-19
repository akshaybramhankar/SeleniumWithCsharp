FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch

 # Install Chrome
 RUN apt-get update && apt-get install -y \
 apt-transport-https \
 ca-certificates \
 curl \
 gnupg \
 hicolor-icon-theme \
 libcanberra-gtk* \
 libgl1-mesa-dri \
 libgl1-mesa-glx \
 libpango1.0-0 \
 libpulse0 \
 libv4l-0 \
 fonts-symbola \
 --no-install-recommends \
 && curl -sSL https://dl.google.com/linux/linux_signing_key.pub | apt-key add - \
 && echo "deb [arch=amd64] https://dl.google.com/linux/chrome/deb/ stable main" > /etc/apt/sources.list.d/google.list \
 && apt-get update && apt-get install -y \
 google-chrome-stable \
 --no-install-recommends \
 && apt-get purge --auto-remove -y curl \
 && rm -rf /var/lib/apt/lists/*

 # Add your dotnet core project build stuff here

WORKDIR /app

EXPOSE 80

EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch

WORKDIR /src

COPY ./ScrapingWithSelenuim/ScrapingWithSelenuim.csproj ./ScrapingWithSelenuim/ScrapingWithSelenuim.csproj

RUN dotnet restore ./ScrapingWithSelenuim/ScrapingWithSelenuim.csproj

COPY . .

WORKDIR "/src/"

RUN dotnet build "./ScrapingWithSelenuim/ScrapingWithSelenuim.csproj" -c Prod -o /app

FROM build AS publish

RUN dotnet publish "./ScrapingWithSelenuim/ScrapingWithSelenuim.csproj" -c Prod -o /app

FROM base AS final

WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "ScrapingWithSelenuim.dll"]