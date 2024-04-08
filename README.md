# REST API example application

Este projeto consiste em uma API de controle de passagens de voo feita em ASP.NET Core e um client feito em Angular.

Abaixo está indicado como  usar a API.

# REST API

Vamos começar com as opções que não são autenticadas

## Get: lista de Voos

### Request

`api/Voo/`

    curl curl -X 'GET' \
  'http://localhost:5164/api/Voo' \
  -H 'accept: text/plain'

### Response

    Success

    [
      {
        "id": 0,
        "partida": "2024-04-08T02:24:50.689Z",
        "chegada": "2024-04-08T02:24:50.689Z",
        "vooClasse": "string",
        "quantidadeAcentos": 0,
        "valor": 0,
        "cidadePartida": "string",
        "cidadeDestino": "string"
      }
    ]

## Post: Comprar passagem

### Request

`POST: /api/Passagem/`

### Body

    {
      "id": 0,
      "nome": "string",
      "cpf": "string",
      "dataNascimento": "2024-04-08T02:27:12.335Z",
      "email": "hB2TzslApE6jV1OrS7IwOYWYWGoLd+u_w1KJG1.ARIizn1nSWOa8url04z%.IGlh7oNfSHnpFcUl@3pEETMxy2CQJIe-Kxs0DV71567RT.vMY",
      "valor": 0,
      "vooId": 0,              
      "bagagemCodigo": "string"
    }

    O campo bagagemCodigo é opcional. A operação irá retornar erro se
    a data de partida do voo for anterior a data atual ou o voo não tiver
    acentos disponíveis
    
### Response

    Success

    {
      "id": 0,
      "nome": "string",
      "cpf": "string",
      "dataNascimento": "2024-04-08T02:27:12.335Z",
      "email": "hB2TzslApE6jV1OrS7IwOYWYWGoLd+u_w1KJG1.ARIizn1nSWOa8url04z%.IGlh7oNfSHnpFcUl@3pEETMxy2CQJIe-Kxs0DV71567RT.vMY",
      "valor": 0,
      "vooId": 0,              
      "bagagemCodigo": "string"
    }

## Listar passagens de um CPF específico

### Request

`GET: /api/Passageiros/cpf`    

### Response

    Success

    [
      {
        "id": 0,
        "nome": "string",
        "cpf": "string",
        "partida": "2024-04-08T08:42:33.153Z",
        "chegada": "2024-04-08T08:42:33.153Z",
        "cidadePartida": "string",
        "cidadeDestino": "string"
      }
    ]

## Fazer Login

### Request

`POST /thing/id`

### Body

    {
      "email": "string",
      "senha": "string"
    }

    Irá retornar não autorizado caso usuario ou senha estejam incorretos.
    
### Response

    Success

    {
      "email": "string",
      "token": "string"
    }

As próximas requisições são autenticadas e deve ter como header :

`Authorization: 'Bearer ' + token`

o espaço depois de Bearer é muito importante.

## Listar Aeroporto

### Request

`Get: api/Aeroporto/`

### Response

    Success

    [
      {
        "id": 0,
        "cidade": "string",
        "nome": "string",
        "iata": "string"
      }
    ]

## Listar Passageiros de um voo

### Request

`GET api/Voo/Passageiros/id`    

### Response

    Success

    [
      {
        "nome": "string",
        "cpf": "string"
      }
    ]

## Adicionar Voo

### Request

`POST api/Voo`

### body

    {
        "id": 0,
        "partida": "2024-04-08T09:23:36.061Z",
        "chegada": "2024-04-08T09:23:36.061Z",
        "vooClasse": 0,
        "quantidadeAcentos": 0,
        "valor": 0,
        "aeroportoId": 0,  
        "aeroportoChegadaId": 0,  
    }

### Response

    Success

    {
        "id": 0,
        "partida": "2024-04-08T09:23:36.061Z",
        "chegada": "2024-04-08T09:23:36.061Z",
        "vooClasse": 0,
        "quantidadeAcentos": 0,
        "valor": 0,
        "aeroportoId": 0,  
        "aeroportoChegadaId": 0,  
    }

## Editar Voo

### Request

`PUT api/Voo/id`

### Voo

    {
        "id": 0,
        "partida": "2024-04-08T09:23:36.061Z",
        "chegada": "2024-04-08T09:23:36.061Z",
        "vooClasse": 0,
        "quantidadeAcentos": 0,
        "valor": 0,
        "aeroportoId": 0,  
        "aeroportoChegadaId": 0,  
    }

### Response

    Success

## Deletar Voo

### Request

`Delete api/Voo/:id`
    
### Response

    Success    

## Attempt to change a Thing using partial params

### Request

`PUT /thing/:id`

    curl -i -H 'Accept: application/json' -X PUT -d 'status=changed3' http://localhost:7000/thing/1

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:32 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 41

    {"id":1,"name":"Foo","status":"changed3"}

## Alterar Passagem

### Request

`PUT api/Passagem/:id`

### Body

    {
      "id": 0,
      "nome": "string",
      "cpf": "string",
      "dataNascimento": "2024-04-08T02:27:12.335Z",
      "email": "hB2TzslApE6jV1OrS7IwOYWYWGoLd+u_w1KJG1.ARIizn1nSWOa8url04z%.IGlh7oNfSHnpFcUl@3pEETMxy2CQJIe-Kxs0DV71567RT.vMY",
      "valor": 0,
      "vooId": 0,              
      "bagagemCodigo": "string"
    }

### Response

    Success

## Deletar Passagem

### Request

`Delete api/Passagem/:id`

### Body

    {
      "id": 0,
      "nome": "string",
      "cpf": "string",
      "dataNascimento": "2024-04-08T02:27:12.335Z",
      "email": "hB2TzslApE6jV1OrS7IwOYWYWGoLd+u_w1KJG1.ARIizn1nSWOa8url04z%.IGlh7oNfSHnpFcUl@3pEETMxy2CQJIe-Kxs0DV71567RT.vMY",
      "valor": 0,
      "vooId": 0,              
      "bagagemCodigo": "string"
    }

### Response

    Success

