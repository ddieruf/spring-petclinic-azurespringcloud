#!/bin/sh

${resourceGroupName}="springpet-clinic"
${serviceInstanceName}="asc-petclinic"
${stagingDeploymentName}="petclinic-staging"

${configServerGitUri}="https://github.com/ddieruf/spring-petclinic-microservices-config"

#Provision ASC
#az extension add --name spring-cloud
#az account set --subscription "XXXXXXX"
az group create --location eastus --name "${resourceGroupName}"
az spring-cloud create -n "${serviceInstanceName}" -g "${resourceGroupName}"
az configure --defaults group="${resourceGroupName}"
az configure --defaults spring-cloud="${serviceInstanceName}"

#Clean up
az group delete --name "${resourceGroupName}" --yes

echo "Setting up config server"
az spring-cloud config-server git set -n "${serviceInstanceName}" --uri "${configServerGitUri}"

echo "Building admin server"
./mvnw install -pl "spring-petclinic-admin-server" -am -P "azureSpringCloud"

echo "Deploying admin server to default environment"
az spring-cloud app create --name "spring-admin-server" --is-public
az spring-cloud app deploy -n "spring-admin-server" --jar-path "spring-petclinic-admin-server/target/spring-petclinic-admin-server-2.3.2.jar"
#az spring-cloud app logs -n "spring-admin-server"

echo "Building api gateway"
./mvnw install -pl "spring-petclinic-api-gateway" -am -P "azureSpringCloud"

echo "Deploying api gateway to default environment"
az spring-cloud app create --name "spring-api-gateway" --is-public
az spring-cloud app deploy -n "spring-api-gateway" --jar-path "spring-petclinic-api-gateway/target/spring-petclinic-api-gateway-2.3.2.jar"

echo "Building customer service"
dotnet publish -c release -o spring-petclinic-customers-service/target spring-petclinic-customers-service/src/main/spring-petclinic-customers-api.csproj

echo "Deploying customer service"
az spring-cloud app create --name "customer-service" --is-public
az spring-cloud app deploy -n "customer-service" -g "${resourceGroupName}" -s "${serviceInstanceName}" --runtime-version NetCore_31 --main-entry customer-service.dll --artifact-path spring-petclinic-customers-service/target/deploy.zip

echo "Building vets service"
dotnet publish -c release -o spring-petclinic-vets-service/target spring-petclinic-vets-service/src/main/spring-petclinic-vets-api.csproj

echo "Deploying vets service"
az spring-cloud app create --name "vets-service" --is-public
az spring-cloud app deploy -n "vets-service" -g "${resourceGroupName}" -s "${serviceInstanceName}" --runtime-version NetCore_31 --main-entry vets-service.dll --artifact-path spring-petclinic-vets-service/target/publish.zip

echo "Building visits service"
dotnet publish -c release -o spring-petclinic-visits-service/target spring-petclinic-visits-service/src/main/spring-petclinic-visits-api.csproj

echo "Deploying visits service"
az spring-cloud app create --name "visits-service" --is-public
az spring-cloud app deploy -n "visits-service" -g "${resourceGroupName}" -s "${serviceInstanceName}" --runtime-version NetCore_31 --main-entry visits-service.dll --artifact-path spring-petclinic-visits-service/target/publish.zip