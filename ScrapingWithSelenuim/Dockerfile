FROM masteroleary/selenium-dotnetcore2.2-linux:v2 AS base

# Install Chrome for Selenium

RUN wget https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb -o /chrome.deb

RUN dpkg -i /chrome.deb || apt-get install -yf

RUN rm /chrome.deb

# Install chromedriver for Selenium

RUN wget https://chromedriver.storage.googleapis.com/2.31/chromedriver_linux64.zip -o /usr/local/bin/chromedriver

RUN chmod +x /usr/local/bin/chromedriver

WORKDIR /app

EXPOSE 80

EXPOSE 443

FROM masteroleary/selenium-dotnetcore2.2-linux:v2 AS build 

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