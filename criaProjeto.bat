SET PROJETO_PADRAO=ProjetoPadraoNetCore

cd ProjetoPadraoNetCore

ren %PROJETO_PADRAO%.ApplicationService %1.ApplicationService
ren %PROJETO_PADRAO%.Domain %1.Domain
ren %PROJETO_PADRAO%.Web %1.Web
ren %PROJETO_PADRAO%.Test %1.Test
ren %PROJETO_PADRAO%.WebApi %1.WebApi
ren %PROJETO_PADRAO%.Repository %1.Repository
ren %PROJETO_PADRAO%.CrossCutting.IoC %1.CrossCutting.IoC
ren %PROJETO_PADRAO%.RabbitMQ %1.RabbitMQ
ren %PROJETO_PADRAO%.SQL %1.SQL

fart %PROJETO_PADRAO%.sln "%PROJETO_PADRAO%." "%1."
fart .gitignore "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.sln %1%.sln

cd %1.ApplicationService
..\fart %PROJETO_PADRAO%.ApplicationService.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.ApplicationService.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart %PROJETO_PADRAO%.ApplicationService.csproj "%PROJETO_PADRAO%.Domain" "%1.Domain"
..\fart AuthenticationService\JwtTokenApplication.cs "%PROJETO_PADRAO%." "%1."
..\fart LoginService\LoginApplication.cs "%PROJETO_PADRAO%." "%1."
..\fart MeuServicoApplicationService.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.ApplicationService.csproj %1%.ApplicationService.csproj
cd ..

cd %1.Domain
..\fart %PROJETO_PADRAO%.Domain.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.Domain.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart Classes\MeuServico.cs "%PROJETO_PADRAO%." "%1."
..\fart Classes\Product.cs "%PROJETO_PADRAO%." "%1."
..\fart Classes\Company.cs "%PROJETO_PADRAO%." "%1."
..\fart Classes\Category.cs "%PROJETO_PADRAO%." "%1."
..\fart Classes\Customer.cs "%PROJETO_PADRAO%." "%1."
..\fart Classes\Image.cs "%PROJETO_PADRAO%." "%1."
..\fart Events\MyServiceIntegrationEvent.cs "%PROJETO_PADRAO%." "%1."
..\fart IApplicationService\IMeuServicoApplicationService.cs "%PROJETO_PADRAO%." "%1."
..\fart IApplicationService\IJwtTokenApplication.cs "%PROJETO_PADRAO%." "%1."
..\fart IApplicationService\ILoginApplication.cs "%PROJETO_PADRAO%." "%1."
..\fart IRepository\IMeuServicoRepository.cs "%PROJETO_PADRAO%." "%1."
..\fart Utilities\Config.cs "%PROJETO_PADRAO%." "%1."
..\fart Utilities\ExceptionErrors.cs "%PROJETO_PADRAO%." "%1."
..\fart Utilities\ErrorStatusCode.cs "%PROJETO_PADRAO%." "%1."
..\fart Utilities\Constants.cs "%PROJETO_PADRAO%." "%1."
..\fart Utilities\PersonalRegisteredClaimNames.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\MeuServicoViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\ProductViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\CompanyViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\CategoryViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\CustomerViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\ImageViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\FilterBaseViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\PagedCollectionViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\JwtTokenViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\BuildTokenViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\AuthenticationViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart ViewModel\LoginViewModel.cs "%PROJETO_PADRAO%." "%1."
..\fart BaseResponse.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.Domain.csproj %1%.Domain.csproj
cd ..

cd %1.WebApi
..\fart %PROJETO_PADRAO%.WebApi.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.WebApi.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart %PROJETO_PADRAO%.WebApi.csproj "%PROJETO_PADRAO%.ApplicationService" "%1.ApplicationService"
..\fart %PROJETO_PADRAO%.WebApi.csproj "%PROJETO_PADRAO%.Domain" "%1.Domain"
..\fart %PROJETO_PADRAO%.WebApi.csproj "%PROJETO_PADRAO%.Repository" "%1.Repository"
..\fart %PROJETO_PADRAO%.WebApi.csproj "%PROJETO_PADRAO%.CrossCutting.IoC" "%1.CrossCutting.IoC"
..\fart Web.config "%PROJETO_PADRAO%." "%1."
..\fart Program.cs "%PROJETO_PADRAO%." "%1."
..\fart Startup.cs "%PROJETO_PADRAO%." "%1."
..\fart Startup.cs "<%PROJETO_PADRAO%DBContext" "<%1Context"
..\fart Controllers\ValuesController.cs "%PROJETO_PADRAO%." "%1."
..\fart Controllers\AuthenticationController.cs "%PROJETO_PADRAO%." "%1."
..\fart Utilities\SecurityFilter.cs "%PROJETO_PADRAO%." "%1."
..\fart Utilities\IHttpContextAccessorExtension.cs "%PROJETO_PADRAO%." "%1."
..\fart Utilities\CustomDateTimeConverter.cs "%PROJETO_PADRAO%." "%1."
..\fart Utilities\TimeSpanConverter.cs "%PROJETO_PADRAO%." "%1."
..\fart Configurations\DatabaseSetup.cs "<%PROJETO_PADRAO%DBContext" "<%1Context"
..\fart Configurations\DatabaseSetup.cs "%PROJETO_PADRAO%." "%1."
..\fart Configurations\SwaggerSetup.cs "%PROJETO_PADRAO%." "%1."
..\fart Configurations\IdentitySetup.cs "%PROJETO_PADRAO%." "%1."
..\fart Configurations\DependencyInjectionSetup.cs "%PROJETO_PADRAO%." "%1."
..\fart Configurations\DependencyInjectionRabbitSetup.cs "%PROJETO_PADRAO%." "%1."
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
..\fart EntityConfiguration\ProductEntityConfiguration.cs "%PROJETO_PADRAO%." "%1."
..\fart EntityConfiguration\CategoryEntityConfiguration.cs "%PROJETO_PADRAO%." "%1."
..\fart EntityConfiguration\ImageEntityConfiguration.cs "%PROJETO_PADRAO%." "%1."
..\fart EntityConfiguration\CustomerEntityConfiguration.cs "%PROJETO_PADRAO%." "%1."
..\fart EntityConfiguration\CompanyEntityConfiguration.cs "%PROJETO_PADRAO%." "%1."
..\fart Repositories\MeuServicoRepository.cs "%PROJETO_PADRAO%." "%1."
..\fart Repositories\MeuServicoRepository.cs "%PROJETO_PADRAO%DBContext" "%1Context"
ren ProjetoPadraoNetCoreDBContext.cs %1Context.cs
cd ..

cd %1.CrossCutting.IoC
..\fart %PROJETO_PADRAO%.CrossCutting.IoC.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.CrossCutting.IoC.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart %PROJETO_PADRAO%.CrossCutting.IoC.csproj "%PROJETO_PADRAO%.ApplicationService" "%1.ApplicationService"
..\fart %PROJETO_PADRAO%.CrossCutting.IoC.csproj "%PROJETO_PADRAO%.Domain" "%1.Domain"
..\fart %PROJETO_PADRAO%.CrossCutting.IoC.csproj "%PROJETO_PADRAO%.Repository" "%1.Repository"
..\fart %PROJETO_PADRAO%.CrossCutting.IoC.csproj "%PROJETO_PADRAO%.RabbitMQ" "%1.RabbitMQ"
..\fart NativeInjectorBootStrapper.cs "%PROJETO_PADRAO%." "%1."
..\fart NativeInjectorBootStrapper.cs "<%PROJETO_PADRAO%DBContext" "<%1Context"
..\fart NativeInjectorRabbitBootStrapper.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.CrossCutting.IoC.csproj %1%.CrossCutting.IoC.csproj
cd ..

cd %1.RabbitMQ
..\fart %PROJETO_PADRAO%.RabbitMQ.csproj "<RootNamespace>%PROJETO_PADRAO%." "<RootNamespace>%1."
..\fart %PROJETO_PADRAO%.RabbitMQ.csproj "<AssemblyName>%PROJETO_PADRAO%." "<AssemblyName>%1."
..\fart %PROJETO_PADRAO%.RabbitMQ.csproj "%PROJETO_PADRAO%.Domain" "%1.Domain"
..\fart MyServiceEventHandler.cs "%PROJETO_PADRAO%." "%1."
ren %PROJETO_PADRAO%.RabbitMQ.csproj %1%.RabbitMQ.csproj
cd ..


cd %1.SQL
..\fart Create.sql "%PROJETO_PADRAO%" "%1"

cd ..
..\fart compile.bat ".\%PROJETO_PADRAO%.WebApi" ".\%1.WebApi"

del fart.exe
del boilerplate.bat
del criaProjeto.bat

REM Sai do diretorio ProjetoPadrao
cd ..

REM Cria um diretório com o nome do projeto
mkdir %1

REM Copia o conteúdo do diretório do projeto padrão já alterado para o diretório correto
xcopy /s ".\%PROJETO_PADRAO%" %1

REM Remove o PeD que não é mais necessário
rmdir /s /q ".\%PROJETO_PADRAO%"