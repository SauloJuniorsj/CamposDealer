
# Projeto CRUD com Clean Architecture e Docker

Esse projeto foi realizado como teste para empresa Campos Dealer, ele satisfaz as condições pedidas

• Em ASP.NET MVC (Projeto Web) 

• Aplicação deve gerenciar uma lista de Vendas (CRUD) 

• Aplicação deve gerenciar uma lista de Produtos (CRUD) 

• Aplicação deve gerenciar uma lista de Clientes (CRUD) 

• Cada Venda contém informações do cliente e do produto de interesse do cliente 

• Permitir que o sistema realize uma carga de informações de Clientes, Vendas e 

Produtos a partir dos endpoints: 
https://camposdealer.dev/Sites/TesteAPI/venda etc

• Utilizar banco de dados para persistir e recuperar os dados (Caso seja utilizado 
Microsoft SQL Server, será considerado um diferencial)

Tecnologias utilizadas : Entity Framework, Docker, Sql Server, Principios SOLID, Jquery, Swagger


## Demonstração

Segue vídeo de como executar o projeto

https://youtu.be/EFBuoO0LZPw
## Start-Up

Esse projeto precisa de docker instalado e executando

```bash
    docker-compose up
  ```
Será apresentada a documentação do Swagger no endpoint 


   ```bash
   https://localhost:8081/index.html
   https://localhost:8080/index.html
  ```

  Para acessar a parte de front-end da aplicação, coloque o seguinte endpoint 
 
  ```bash
    https://localhost:8081/client/index     ou
    https://localhost:8081/Products/Index   ou
    https://localhost:8081/Sales/Index
  ```
## Referência

 - [Awesome Readme Templates](https://awesomeopensource.com/project/elangosundar/awesome-README-templates)
 - [Awesome README](https://github.com/matiassingers/awesome-readme)
 - [How to write a Good readme](https://bulldogjob.com/news/449-how-to-write-a-good-readme-for-your-github-project)

