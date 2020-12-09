# Siteware Backend

Aplicação disponivel em: https://Siteware.azurewebsites.net/

O Backend foi desenvolvido em .NET Core 3.1, utilizando DDD, DI, Inversion of Control, REST e Repository Pattern

  - Service 
    - É a camada responsavel por fazer a interface com outras aplicações, nesse caso esta modelado como um projeto de api RESTful.
  - Application
    - Camada responsavel por transformação ded dado, isolando a lógica de regra de negocio e entidades do DTO.
  - Domain
    - Camada em que ficam as regras de negocio da aplicação
  - Infra IOT
    - Camada responsavel por fazer a inversão de controle por meio de injeção de dependencia
  - Infra Data
    - Camada responsavel por mediar o acesso a dados

A ferramenta de teste utilizada é o Xunit, sendo que toda camada de dominio que contem as regras de negocio da aplicação está coberta.

### Run Application


```sh
$ cd uol-edtech-backend
$ dotnet build
$ dotnet run
```
