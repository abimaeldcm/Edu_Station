# Edu Station

Edu Station é um sistema de gerenciamento escolar construído na arquitetura MVC (Model-View-Controller), utilizando o padrão Repository e Service, além do Entity Framework Core como ORM (Object-Relational Mapping) e o banco de dados SQL Server.

O sistema permite realizar operações CRUD (Create, Read, Update, Delete) para docentes, alunos, turmas, diretores e disciplinas.

[![Vídeo de Demonstração]](https://youtu.be/qJJ7VMYLBkg)

## Recursos

- CRUD de Docente
- CRUD de Aluno
- CRUD de Turmas
- CRUD de Diretores
- CRUD de Disciplinas

## Pré-requisitos

- Visual Studio 2019 ou superior
- SQL Server Management Studio (SSMS)
- .NET Core 3.1 SDK ou superior

## Configuração do Banco de Dados

1. Instale o SQL Server e o SQL Server Management Studio (SSMS) se ainda não estiverem instalados.
2. Crie um banco de dados no SQL Server.
3. Abra o arquivo `appsettings.json` no projeto e ajuste a string de conexão (`DefaultConnection`) para se conectar ao seu banco de dados.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEUSERVIDOR;Database=SEUBANCODEDADOS;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  ...
}
