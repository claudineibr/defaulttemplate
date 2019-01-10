SET PROJETO_PADRAO=ProjetoPadraoNetCore

cd ProjetoPadraoNetCore

ren %PROJETO_PADRAO%.Web %1.Web
ren %PROJETO_PADRAO%.ApplicationService %1.ApplicationService
ren %PROJETO_PADRAO%.Domain %1.Domain
ren %PROJETO_PADRAO%.WebApi %1.WebApi
ren %PROJETO_PADRAO%.Repository %1.Repository
ren %PROJETO_PADRAO%.Test %1.Test

fart %PROJETO_PADRAO%.sln "%PROJETO_PADRAO%." "%1."
fart .gitignore "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.sln %1%.sln

cd %1.Web
..\fart %PROJETO_PADRAO%.Web.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.Web.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart %PROJETO_PADRAO%.Web.csproj "%PROJETO_PADRAO%.ApplicationService" "%1.ApplicationService"
..\fart %PROJETO_PADRAO%.Web.csproj "%PROJETO_PADRAO%.Domain" "%1.Domain"
..\fart %PROJETO_PADRAO%.Web.csproj "%PROJETO_PADRAO%.Repository" "%1.Repository"
..\fart Program.cs "%PROJETO_PADRAO%." "%1."
..\fart Views\_ViewImports.cshtml "%PROJETO_PADRAO%." "%1."
..\fart Startup.cs "%PROJETO_PADRAO%." "%1."
..\fart Startup.cs "<%PROJETO_PADRAO%DBContext" "<%1Context"
..\fart Models\ErrorViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart Controllers\HomeController.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.Web.csproj %1%.Web.csproj
cd ..

cd %1.ApplicationService
..\fart %PROJETO_PADRAO%.ApplicationService.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.ApplicationService.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart %PROJETO_PADRAO%.ApplicationService.csproj "%PROJETO_PADRAO%.Domain" "%1.Domain"
..\fart MeuServicoApplicationService.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.ApplicationService.csproj %1%.ApplicationService.csproj
cd ..

cd %1.Domain
..\fart %PROJETO_PADRAO%.Domain.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.Domain.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart Classes\MeuServico.cs "%PROJETO_PADRAO%." "%1."
..\fart IApplicationService\IMeuServicoApplicationService.cs "%PROJETO_PADRAO%." "%1."
..\fart IRepository\IMeuServicoRepository.cs "%PROJETO_PADRAO%." "%1."
..\fart Utilities\Config.cs "%PROJETO_PADRAO%." "%1."
..\fart Utilities\Util.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\MeuServicoViewModel.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.Domain.csproj %1%.Domain.csproj
cd ..

cd %1.WebApi
..\fart %PROJETO_PADRAO%.WebApi.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.WebApi.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart %PROJETO_PADRAO%.WebApi.csproj "%PROJETO_PADRAO%.ApplicationService" "%1.ApplicationService"
..\fart %PROJETO_PADRAO%.WebApi.csproj "%PROJETO_PADRAO%.Domain" "%1.Domain"
..\fart %PROJETO_PADRAO%.WebApi.csproj "%PROJETO_PADRAO%.Repository" "%1.Repository"
..\fart Web.config "%PROJETO_PADRAO%." "%1."
..\fart Program.cs "%PROJETO_PADRAO%." "%1."
..\fart Startup.cs "%PROJETO_PADRAO%." "%1."
..\fart Startup.cs "<%PROJETO_PADRAO%DBContext" "<%1Context"
..\fart Controllers\ValuesController.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.WebApi.csproj %1%.WebApi.csproj
cd ..

cd %1.Repository
..\fart %PROJETO_PADRAO%.Repository.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.Repository.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart %PROJETO_PADRAO%.Repository.csproj "%PROJETO_PADRAO%.Domain" "%1.Domain"
ren %PROJETO_PADRAO%.Repository.csproj %1%.Repository.csproj
..\fart ProjetoPadraoNetCoreDBContext.cs "%PROJETO_PADRAO%." "%1."
..\fart ProjetoPadraoNetCoreDBContext.cs "%PROJETO_PADRAO%DBContext " "%1Context "
..\fart ProjetoPadraoNetCoreDBContext.cs "%PROJETO_PADRAO%DBContext()" "%1Context()"
..\fart ProjetoPadraoNetCoreDBContext.cs "=%PROJETO_PADRAO%DBContext" "=%1Context"
..\fart ProjetoPadraoNetCoreDBContext.cs "<%PROJETO_PADRAO%DBContext" "<%1Context"
..\fart ProjetoPadraoNetCoreDBContext.cs "%PROJETO_PADRAO%DBContext(" "%1Context("
..\fart EntityConfiguration\MeuServicoEntityConfiguration.cs "%PROJETO_PADRAO%." "%1."
..\fart Repositories\MeuServicoRepository.cs "%PROJETO_PADRAO%." "%1."
..\fart Repositories\MeuServicoRepository.cs "%PROJETO_PADRAO%DBContext" "%1Context"
ren ProjetoPadraoNetCoreDBContext.cs %1Context.cs
cd ..


cd %1.Test
..\fart %PROJETO_PADRAO%.Test.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.Test.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart %PROJETO_PADRAO%.Test.csproj "%PROJETO_PADRAO%.ApplicationService" "%1.ApplicationService"
..\fart %PROJETO_PADRAO%.Test.csproj "%PROJETO_PADRAO%.Repository" "%1.Repository"
..\fart MeuServicoApplicationUnitTest.cs "<%PROJETO_PADRAO%DBContext" "<%1Context"
..\fart MeuServicoApplicationUnitTest.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.Test.csproj %1%.Test.csproj
cd ..

del fart.exe
del bootstrap.bat
del criaProjeto.bat
del _criaProjeto.bat

REM Sai do diretorio ProjetoPadrao
cd ..

REM Cria um diretório com o nome do projeto
mkdir %1

REM Copia o conteúdo do diretório do projeto padrão já alterado para o diretório correto
xcopy /s ".\%PROJETO_PADRAO%" %1

REM Remove o PeD que não é mais necessário
rmdir /s /q ".\%PROJETO_PADRAO%"