rd /Q /S %client-name%

java -jar %swagger-codegen-cli-jar% generate ^
		-i %swagger-descriptor-path% ^
		-l csharp ^
		-c %dir-cfg%/web-api-client.cfg.json ^
		-o %client-name%

dotnet restore %client-name%/%src%
dotnet build %client-name%/%src%
