<h1 align="center">
  Agenda.API
</h1>
<p align="center">
  <a href="#tecnologias-e-práticas-utilizadas">Tecnologias e práticas utilizadas</a> •
  <a href="#funcionalidades">Funcionalidades</a> •
  <a href="#comandos">Comandos</a>
</p>

Foi desenvolvida uma API REST para gerenciamento de uma agenda.

_OBS.: Esse é um projeto de estudo! Existem técnicas, métodos e tecnologias não usadas ou reduntantes._

## Tecnologias e práticas utilizadas
- ASP.NET Core com .NET 8
- Entity Framework Core
- In-Memory database
- Swagger
- AutoMapper
- Programação Orientada a Objetos
- Injeção de Dependência
- Padrão Repository
- Logs com Serilog
- Validações com DataAnnotations e FluentValidations
- Testes com xUnit, __AutoFixture__, Moq e Shouldly
- Analise de performance com BenchmarkDotNet
- Clean Code
- Publicação

## Funcionalidades
- Adição, Atualização, Remoção e Listagem de Contatos
- Adição, Atualização, Remoção e Listagem de Eventos
- Adição, Atualização, Remoção e Listagem de Tarefas

###

![alt text](https://raw.githubusercontent.com/samuel-oldra/Agenda.API/main/README_IMGS/swagger_ui.png)

## Comandos

### Comandos básicos
```
dotnet new gitignore
dotnet new webapi -o Agenda.API -f net8.0

dotnet build
dotnet run
dotnet run --configuration Release
dotnet watch run

dotnet test

dotnet publish
```