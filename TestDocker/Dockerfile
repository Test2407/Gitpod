FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build 
WORKDIR /src
COPY . .
RUN dotnet restore 
RUN dotnet add package Microsoft.Playwright.NUnit --version 1.43.0
RUN dotnet build
RUN pwsh ./bin/Debug/net8.0/playwright.ps1 install
ENTRYPOINT ["dotnet", "test","--settings=test.runsettings"]