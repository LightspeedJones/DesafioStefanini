# DesafioStefanini


A aplicação foi feita com uma camada back-end escrita em .NET 6.0 (usando um banco InMemory integrado com o EF Core) e uma outra camada front-end escrita com o framework Angular.


Para executar é necessário que o Visual Studio esteja instalado. Depois de executar o projeto, a camada front-end estará disponível para acesso em http://localhost:4200/ e a camada back-end estará disponível em https://localhost:7297. Para visualizar todos os métodos disponiveis, visite https://localhost:7297/swagger.

/Pedidos/GetPedidos - Retorna todos os pedidos na base

/Pedidos/GetPedidoPorId/{id} - Retorna um único pedido a partir do seu Id

/CriarPedido - Cria um novo pedido na base

/AtualizarPedido - Atualiza um pedido existente

/DeletarPedido - Remove um pedido existente
