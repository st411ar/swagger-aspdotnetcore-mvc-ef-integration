# swagger-aspdotnetcore-mvc-ef-integration
Web application "Paper Library" demonstrates integration of **swagger** with **asp.net core** + **mvc** + **ef**
## content
1. swagger codegen
1. web api server
1. web api client
1. web api client checker
1. web application "Paper Library"
## requirements
1. internet
1. windows (>= 7 SP1)
1. mysql server
1. git
1. java se jdk
1. maven
1. .net core sdk 2.x
1. mysql connector net
## validated
- arch x86
- windows 7 SP1
- mysql server 5.7.20
- git
  - 2.15.1.windows.2
  - 2.16.0.windows.2
- java se jdk
  - 1.8.152
  - 1.8.162
- maven 3.5.2
- .net core sdk 2.1.4
- mysql connector net 6.10.5
## setup
```
git clone https://github.com/st411ar/swagger-aspdotnetcore-mvc-ef-integration.git
cd swagger-aspdotnetcore-mvc-ef-integration
setup
```
## run web api server
```
run-web-api
```
## run web api client checker
```
run-web-api-client-checker
```
## run web application "Paper Library"
```
run-web-app
```
## next
- add auth to api
- move part of auth logic from app to api
- change app auth to filter based
- improve password security (hash, carefully with heap)
- improve ui
- create custom swagger library for asp.net core ef
- remove redundant tabs and pages
- remove some hardcode (e.g. ui user roles edit)
- move part of views to view models
- implements roles with help of enums