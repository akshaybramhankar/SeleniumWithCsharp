FROM masteroleary/selenium-dotnetcore2.2-linux:v2 AS base

# Install Chrome for Selenium

RUN wget https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb -o /chrome.deb

RUN dpkg -i /chrome.deb || apt-get install -yf

RUN rm /chrome.deb

# Install chromedriver for Selenium

RUN apt-get update

RUN apt-get install unzip

RUN wget -N https://chromedriver.storage.googleapis.com/75.0.3770.140/chromedriver_linux64.zip -P ~/Downloads

RUN unzip ~/Downloads/chromedriver_linux64.zip -d ~/Downloads

RUN mv -f ~/Downloads/chromedriver /usr/local/bin/

RUN chmod +x /usr/local/bin/chromedriver

# Create symbolic links
#RUN ln -s /usr/local/bin/chromedriver /usr/local/bin/chromedriver

RUN ln -s /usr/local/bin/chromedriver /usr/bin/chromedriver

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