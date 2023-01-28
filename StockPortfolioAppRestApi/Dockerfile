#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM jenkins:1.596
 
USER root
RUN apt-key adv --keyserver keyserver.ubuntu.com --recv-keys 605C66F00D6C9793 \
  && apt-key adv --keyserver keyserver.ubuntu.com --recv-keys 0E98404D386FA1D9 \
  && apt-key adv --keyserver keyserver.ubuntu.com --recv-keys 648ACFD622F3D138 \
      && apt-get update \
      && apt-get install -y --force-yes sudo \
      && rm -rf /var/lib/apt/lists/*
RUN echo "jenkins ALL=NOPASSWD: ALL" >> /etc/sudoers

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StockPortfolioAppRestApi/StockPortfolioApp.csproj", "."]
RUN dotnet restore "./StockPortfolioApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "StockPortfolioApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockPortfolioApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockPortfolioApp.dll"]
