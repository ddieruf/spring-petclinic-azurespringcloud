dotnet new sln --output spring-petclinic-customers-service\src --name spring-petclinic-customers-service

dotnet new web --output spring-petclinic-customers-service\src\main --name spring-petclinic-customers-api --framework "netcoreapp3.1"
dotnet sln spring-petclinic-customers-service\src\spring-petclinic-customers-service.sln add .\spring-petclinic-customers-service\src\main\spring-petclinic-customers-api.csproj

dotnet new xunit --output spring-petclinic-customers-service\src\test\unit --name spring-petclinic-customers-unit-test --framework "netcoreapp3.1"
dotnet sln spring-petclinic-customers-service\src\spring-petclinic-customers-service.sln add .\spring-petclinic-customers-service\src\test\unit\spring-petclinic-customers-unit-test.csproj

dotnet new xunit --output spring-petclinic-customers-service\src\test\integration --name spring-petclinic-customers-integration-test --framework "netcoreapp3.1"
dotnet sln spring-petclinic-customers-service\src\spring-petclinic-customers-service.sln add .\spring-petclinic-customers-service\src\test\integration\spring-petclinic-customers-integration-test.csproj

mkdir spring-petclinic-customers-service\src\ci
New-Item -ItemType file spring-petclinic-customers-service\src\readme.md

#INITIALIZE DATABASE MODEL
docker run -e 'ACCEPT_EULA=Y' -e "MSSQL_SA_PASSWORD=NOPasswordd1123!!" --name petclinic -p 127.0.0.1:1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04

dotnet new console --output temp-scaffold --name temp-scaffold --framework "netcoreapp3.1"
cd temp-scaffold
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet ef dbcontext scaffold "Data Source=127.0.0.1,1433;Initial Catalog=petclinic;User Id=sa;Password=NOPasswordd1123!!" Microsoft.EntityFrameworkCore.SqlServer `
	--context-dir "V1/Data" `
	--output-dir "V1/DTOs" `
	--context "CustomersContext" `
	--force `
	--verbose
