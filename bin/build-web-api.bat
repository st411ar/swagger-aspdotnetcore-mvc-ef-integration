rd /Q /S %web-api-name%

java -jar %swagger-codegen-cli-jar% generate ^
		-i %swagger-descriptor-path% ^
		-l aspnetcore ^
		-o %web-api-name%

dotnet add %web-api-name%/%src% package Microsoft.AspNetCore.Cors
dotnet add %web-api-name%/%src% package MySql.Data.EntityFrameworkCore
xcopy custom\%web-api-name% %web-api-name% /S /I /Y
cd %web-api-name%
call build
cd ..
