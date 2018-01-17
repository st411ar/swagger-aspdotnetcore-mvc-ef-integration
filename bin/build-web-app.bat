rd /Q /S %web-app-name%
dotnet new mvc -o %web-app-name%
xcopy custom\%web-app-name% %web-app-name% /S /I /Y
dotnet add %web-app-name% reference %client-name%/%src%/IO.Swagger.csproj
dotnet restore %web-app-name%
dotnet build %web-app-name%
