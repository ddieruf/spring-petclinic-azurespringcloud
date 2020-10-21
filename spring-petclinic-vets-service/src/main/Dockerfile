FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster as builder
WORKDIR application
COPY ["spring-petclinic-vets-api.csproj", ""]
RUN dotnet restore -s "https://api.nuget.org/v3/index.json" -s "https://www.myget.org/F/steeltoedev/api/v3/index.json"
COPY . .
RUN dotnet publish -c Release -o publish

# Download dockerize and cache that layer
ARG DOCKERIZE_VERSION=v0.6.1
RUN wget -O dockerize.tar.gz https://github.com/jwilder/dockerize/releases/download/${DOCKERIZE_VERSION}/dockerize-alpine-linux-amd64-${DOCKERIZE_VERSION}.tar.gz
RUN tar xzf dockerize.tar.gz
RUN chmod +x dockerize

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR application

# Dockerize
COPY --from=builder application/dockerize /usr/local/bin/dockerize

ARG EXPOSED_PORT=5000
EXPOSE ${EXPOSED_PORT}
ENV ASPNETCORE_ENVIRONMENT Docker

COPY --from=builder application/publish .
ENTRYPOINT ["dotnet", "vets-service.dll"]