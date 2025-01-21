# 1 - Realiza o download do .net na máquina
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build 

# 2 - Ao que parece este workdir é o diretório onde os próximos comandos serão executados
WORKDIR /src 

# 3 - Copia o .sln e os arquivos .csproj pra dentro do container
COPY *.sln .
COPY CleanArchMVC.Application/*.csproj CleanArchMVC.Application/
COPY CleanArchMVC.Domain/*.csproj CleanArchMVC.Domain/
COPY CleanArchMVC.Domain.Tests/*.csproj CleanArchMVC.Domain.Tests/
COPY CleanArchMVC.Infra.Data/*.csproj CleanArchMVC.Infra.Data/
COPY CleanArchMVC.Infra.IoC/*.csproj CleanArchMVC.Infra.IoC/
COPY CleanArchMVC.WebUI/*.csproj CleanArchMVC.WebUI/

# 4 - Faz o o download das dependencias indicadas nos arquivos .csproj
RUN dotnet restore

# 5 Copia o restante do projeto para dentro do container
COPY . .

# 6 Executa o publish do projeto
RUN dotnet publish -c release -o /app

# 7 Esse passo eu não entendi
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80

ENTRYPOINT ["dotnet", "CleanArchMVC.WebUI.dll"]