rd /Q /S %checker-name%
dotnet new console -o %checker-name%
xcopy custom\%checker-name% %checker-name% /S /I /Y
dotnet add %checker-name% reference %client-name%/%src%/IO.Swagger.csproj
dotnet restore %checker-name%
dotnet build %checker-name%
