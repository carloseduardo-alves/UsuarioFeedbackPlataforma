# UsuarioFeedbackPlataforma

Este projeto é uma plataforma de feedback de usuários, desenvolvida em **ASP.NET Core**, que segue as boas práticas de **Clean Architecture**, e implementa os padrões **CQRS** (Command Query Responsibility Segregation) e **Repository Pattern**. O objetivo é permitir que os usuários enviem, editem, excluam e visualizem feedbacks de maneira eficiente e escalável.

## Índice

 [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Arquitetura](#arquitetura)
- [Pré-requisitos](#pré-requisitos)
- [Como Instalar e Executar o Projeto](#como-instalar-e-executar-o-projeto)
- [Como Usar](#como-usar)
- [Endpoints da API](#endpoints-principais)
- [Contribuições](#contribuições)
- [Licença](#licença)

## Funcionalidades

- **Enviar Feedback**: Usuários podem enviar feedbacks com nome de usuário, mensagem e data de criação.
- **Editar Feedback**: Permite a edição de feedbacks existentes, atualizando nome, mensagem ou outros dados.
- **Excluir Feedback**: Permite a remoção de feedbacks pelo ID.
- **Listar Feedbacks**: Exibe todos os feedbacks cadastrados na plataforma.
- **Buscar Feedback por ID**: Recupera um feedback específico a partir do seu ID.

## Tecnologias Utilizadas

- **ASP.NET Core 7.0**
- **Clean Architecture** para organização do código e responsabilidades bem definidas
- **CQRS com MediatR** para separação de comandos e consultas
- **Repository Pattern** para abstração do acesso ao banco de dados
- **Entity Framework Core** para persistência de dados
- **Fluent Validation** para validação dos dados de entrada
- **Swagger** para documentação da API
- **Banco de Dados**: SQL Server

## Arquitetura

O projeto segue o princípio da **Clean Architecture**, garantindo uma separação clara entre as camadas da aplicação e facilitando a manutenção e escalabilidade. Ele está dividido nas seguintes camadas:

1. **UsuarioFeedbackPlataforma.Api**: Contém os controladores da API e as configurações do projeto.
2. **UsuarioFeedbackPlataforma.Application**: Abriga os casos de uso, como comandos (Commands) e consultas (Queries), além das validações e regras de negócio.
3. **UsuarioFeedbackPlataforma.Core**: Define as entidades do domínio, os enums e as interfaces principais. Aqui ficam as regras de negócio centrais.
4. **UsuarioFeedbackPlataforma.Infrastructure**: Implementa o padrão **Repository Pattern**, responsável por lidar com o acesso a dados, persistência e o **DbContext**.

Utilizando o padrão **CQRS**, as operações de escrita e leitura são separadas. Isso garante maior organização e escalabilidade, especialmente em cenários complexos. Além disso, o **Repository Pattern** abstrai as interações com o banco de dados, facilitando testes e manutenção.

## Pré-requisitos

Antes de executar o projeto, você precisará ter instalado em seu ambiente:

- **.NET 7.0 SDK** ou superior
- **SQL Server** ou outro banco de dados compatível
- **Git** (para clonar o repositório)
- **Ferramenta de gerenciamento de pacotes NuGet** (embutido no .NET SDK)
- Um cliente de API como o **Postman** ou **Insomnia** (opcional, para testar os endpoints)

## Como Instalar e Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/carloseduardo-alves/UsuarioFeedbackPlataforma.git

2. Entre no diretório do projeto:
   ```bash
   cd UsuarioFeedbackPlataforma
   ```
   
3. Configure a string de conexão com o banco de dados no arquivo appsettings.json:
   ```bash
   "ConnectionStrings": {
   "DefaultConnection": "Server=SEU_SERVIDOR; Database=UsuarioFeedbackDB; Trusted_Connection=True;"}

4. Restaure as dependências:
   ```bash
   dotnet restore
   ```

5. Crie o banco de dados (certifique-se de que sua conexão com o banco esteja configurada corretamente):
   ```bash
   dotnet ef database update
   ```

6. Rode o projeto: 
   ```bash
   dotnet run --project UsuarioFeedbackPlataforma.Api
   ```

7. Acesse a documentação da API no navegador:
http://localhost:5000/swagger

## Como usar
1. Listar Feedbacks - Utilize o método GET no endpoint /api/feedback para obter uma lista de todos os feedbacks cadastrados.
2. Buscar um Feedback por ID - Faça uma requisição GET para o endpoint /api/feedback/{id} para obter um feedback específico pelo ID.
3. Enviar um Feedback - Acesse o endpoint /api/feedback com o método POST no Swagger ou via um cliente como o Postman. Envie um JSON no corpo da requisição.
4. Editar um Feedback - Utilize o endpoint /api/feedback/{id} com o método PUT para atualizar um feedback existente.
5. Excluir um Feedback - Para remover um feedback, faça uma requisição DELETE ao endpoint /api/feedback/{id}, onde {id} é o ID do feedback que deseja remover.

### Endpoints principais:
- **GET** `/api/feedback` - Lista todos os feedback.
- **GET** `/api/feedback/{id}` - Busca um feedback específico pelo ID.
- **POST** `/api/feedback` - Cria um novo feedback.
- **PUT** `/api/feedback/{id}` - Atualiza um feedback existente.
- **DELETE** `/api/feedback/{id}` - Deleta um feedback pelo ID.

## Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença
Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.











