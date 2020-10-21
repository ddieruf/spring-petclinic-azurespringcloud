dotnet new sln --output spring-petclinic-vets-service\src --name spring-petclinic-vets-service

dotnet new web --output spring-petclinic-vets-service\src\main --name spring-petclinic-vets-api --framework "netcoreapp3.1"
dotnet sln spring-petclinic-vets-service\src\spring-petclinic-vets-service.sln add .\spring-petclinic-vets-service\src\main\spring-petclinic-vets-api.csproj

dotnet new xunit --output spring-petclinic-vets-service\src\test\unit --name spring-petclinic-vets-unit-test --framework "netcoreapp3.1"
dotnet sln spring-petclinic-vets-service\src\spring-petclinic-vets-service.sln add .\spring-petclinic-vets-service\src\test\unit\spring-petclinic-vets-unit-test.csproj

dotnet new xunit --output spring-petclinic-vets-service\src\test\integration --name spring-petclinic-vets-integration-test --framework "netcoreapp3.1"
dotnet sln spring-petclinic-vets-service\src\spring-petclinic-vets-service.sln add .\spring-petclinic-vets-service\src\test\integration\spring-petclinic-vets-integration-test.csproj

mkdir spring-petclinic-vets-service\src\ci
New-Item -ItemType file spring-petclinic-vets-service\src\readme.md

#INITIALIZE DATABASE MODEL
docker run -e 'ACCEPT_EULA=Y' -e "MSSQL_SA_PASSWORD=NOPasswordd1123!!" --name petclinic -p 127.0.0.1:1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04

dotnet new console --output temp-scaffold --name temp-scaffold --framework "netcoreapp3.1"
cd temp-scaffold
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet ef dbcontext scaffold "Data Source=127.0.0.1,1433;Initial Catalog=petclinic;User Id=sa;Password=NOPasswordd1123!!" Microsoft.EntityFrameworkCore.SqlServer `
	--context-dir "Data" `
	--output-dir "DTOs" `
	--context "vetsContext" `
	--force
