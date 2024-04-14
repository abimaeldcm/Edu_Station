# Edu Station

Edu Station é um sistema de gerenciamento escolar construído na arquitetura MVC (Model-View-Controller), utilizando o padrão Repository e Service, além do Entity Framework Core como ORM (Object-Relational Mapping) e o banco de dados SQL Server.

O sistema permite realizar operações CRUD (Create, Read, Update, Delete) para docentes, alunos, turmas, diretores e disciplinas.


### Clique na imagem abaixo para ver o vídeo
[![Vídeo de Demonstração](https://img.youtube.com/vi/qJJ7VMYLBkg/maxresdefault.jpg)](https://youtu.be/qJJ7VMYLBkg)

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

# Documentação do Projeto Edu_Station

## Visão Geral

O projeto Edu_Station é uma aplicação web desenvolvida para auxiliar instituições educacionais na gestão de alunos, docentes, disciplinas, turmas e diretores. Ele oferece recursos para gerenciar informações sobre usuários e entidades relacionadas, permitindo a criação, edição, exclusão e visualização desses dados.

## Estrutura do Projeto

O projeto está organizado em camadas, seguindo uma arquitetura MVC (Model-View-Controller), com as seguintes estruturas principais:

1. **Models:** Contém as classes que representam as entidades do sistema, como Aluno, Docente, Diretor, Disciplina e Turma.

2. **Controllers:** Contém os controladores responsáveis por receber as requisições HTTP, processar as entradas do usuário, interagir com os serviços e retornar as respostas adequadas.

3. **Views:** Contém os arquivos de visualização que definem a interface do usuário, geralmente escritos em HTML com suporte para código C# usando Razor.

4. **Service Interfaces:** Define as interfaces para os serviços que realizam operações CRUD (Create, Read, Update, Delete) nas entidades do sistema.

5. **Helpers:** Contém classes utilitárias e auxiliares utilizadas em diferentes partes do sistema.

6. **Sessão do Usuário:** Gerencia a sessão do usuário e fornece funcionalidades relacionadas à autenticação e autorização.

7. **Enum:** Contém enumerações utilizadas para representar valores fixos, como o perfil do usuário (Diretor, Docente, Aluno).

## Controladores Principais

### 1. LoginController

Responsável pela autenticação de usuários e funcionalidades relacionadas à senha esquecida. Oferece métodos para login, recuperação de senha e alteração de senha.

### 2. DiretorController

Gerencia as operações CRUD relacionadas aos diretores, incluindo criação, edição, exclusão e visualização.

### 3. DocenteController

Realiza operações CRUD para os docentes, incluindo manipulação de disciplinas associadas.

### 4. DisciplinaController

Responsável pelo gerenciamento das disciplinas, permitindo a criação, edição, exclusão e associação com docentes.

## Serviços

O projeto utiliza serviços para realizar operações de persistência e lógica de negócios. As interfaces de serviço são implementadas por classes concretas que interagem com o banco de dados e fornecem funcionalidades específicas.

## Autenticação e Segurança

O sistema utiliza hashes de senha com a biblioteca BCrypt.Net para armazenar senhas de forma segura. Além disso, são implementadas medidas para proteger as rotas sensíveis e validar as permissões dos usuários.

## Considerações Finais

Esta documentação fornece uma visão geral do projeto Edu_Station, suas principais funcionalidades, estrutura e implementações. Para obter informações mais detalhadas sobre cada parte do sistema, consulte o código-fonte e os comentários fornecidos.

