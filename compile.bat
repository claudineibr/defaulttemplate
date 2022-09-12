@echo off
d:

@echo * Publishing API *
del /s /q .\deploy\prod
del /s /q .\deploy.rar
cd .\ProjetoPadraoNetCore.WebApi

@dotnet publish --framework netcoreapp2.0 --configuration Release --output  ..\deploy\prod

cd .. 

del /s /q .\deploy\prod\config.json
del /s /q .\deploy\prod\*.pdb

"%ProgramFiles%\WinRAR\Rar.exe" a -ep1 -idq -r -y "deploy" ".\deploy\prod\"

@echo * API published *

pause
exit