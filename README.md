# API de Catálogo Restful

Uma API de catálogo restful para gerenciamento de produtos e categorias.

## Tecnologias utilizadas
- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT (JSON Web Token)

## Funcionalidades

### Categorias
- Listar todas as categorias
- Obter uma categoria por ID
- Criar uma nova categoria
- Atualizar informações de uma categoria existente
- Excluir uma categoria

### Produtos
- Listar todos os produtos
- Obter um produto por ID
- Criar um novo produto
- Atualizar informações de um produto existente
- Excluir um produto

### Autenticação
- Login de usuário
- Gerar token JWT para autenticação

## Configuração
Certifique-se de ter o .NET Core SDK instalado em sua máquina.

1. Clone este repositório para o seu ambiente local.
2. Abra o arquivo appsettings.json e atualize a string de conexão do banco de dados, se necessário.
3. Abra o terminal na raiz do projeto e execute o comando `dotnet ef database update` para criar as tabelas do banco de dados.
4. Execute o comando `dotnet run` para iniciar o aplicativo.
5. O aplicativo estará disponível em http://localhost:5000.

## API Endpoints

### Categorias
- GET /categorias - Obtém todas as categorias.
- GET /categorias/{id} - Obtém uma categoria por ID.
- POST /categorias - Cria uma nova categoria.
- PUT /categorias/{id} - Atualiza as informações de uma categoria existente.
- DELETE /categorias/{id} - Exclui uma categoria por ID.
### Produtos
- GET /produtos - Obtém todos os produtos.
- GET /produtos/{id} - Obtém um produto por ID.
- POST /produtos - Cria um novo produto.
- PUT /produtos/{id} - Atualiza as informações de um produto existente.
- DELETE /produtos/{id} - Exclui um produto por ID.
### Autenticação
- POST /login - Realiza o login do usuário e retorna um token JWT válido.
