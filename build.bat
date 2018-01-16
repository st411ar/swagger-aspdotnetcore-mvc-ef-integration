chcp 65001
@setlocal
set start=%time%

:: directory with scripts
set dir-bin=bin
set dir-cfg=cfg

:: mysql
set mysql-root-password=root
set mysql-dump-path=%dir-cfg%/dump.sql

:: web-api
set swagger-codegen-cli-jar=swagger-codegen/modules/swagger-codegen-cli/target/swagger-codegen-cli.jar
set swagger-descriptor-path=%dir-cfg%/swagger.json
set web-api-name=web-api
set src=src/IO.Swagger

:: web-api-client
set client-name=web-api-client

:: web-api-client-checker
set checker-name=web-api-client-checker

:: build all
call %dir-bin%/deploy-db
call %dir-bin%/build-swagger
call %dir-bin%/build-web-api
call %dir-bin%/build-web-api-client
call %dir-bin%/build-web-api-client-checker

:: project have been built
set end=%time%
echo "setup has been started at %start%"
echo "setup has been finished at %end%"



