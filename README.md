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

## Change a Thing's state

### Request

`PUT /thing/:id/status/changed`

    curl -i -H 'Accept: application/json' -X PUT http://localhost:7000/thing/1/status/changed

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:31 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 40

    {"id":1,"name":"Foo","status":"changed"}

## Get changed Thing

### Request

`GET /thing/id`

    curl -i -H 'Accept: application/json' http://localhost:7000/thing/1

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:31 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 40

    {"id":1,"name":"Foo","status":"changed"}

## Change a Thing

### Request

`PUT /thing/:id`

    curl -i -H 'Accept: application/json' -X PUT -d 'name=Foo&status=changed2' http://localhost:7000/thing/1

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:31 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 41

    {"id":1,"name":"Foo","status":"changed2"}

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

## Attempt to change a Thing using invalid params

### Request

`PUT /thing/:id`

    curl -i -H 'Accept: application/json' -X PUT -d 'id=99&status=changed4' http://localhost:7000/thing/1

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:32 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 41

    {"id":1,"name":"Foo","status":"changed4"}

## Change a Thing using the _method hack

### Request

`POST /thing/:id?_method=POST`

    curl -i -H 'Accept: application/json' -X POST -d 'name=Baz&_method=PUT' http://localhost:7000/thing/1

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:32 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 41

    {"id":1,"name":"Baz","status":"changed4"}

## Change a Thing using the _method hack in the url

### Request

`POST /thing/:id?_method=POST`

    curl -i -H 'Accept: application/json' -X POST -d 'name=Qux' http://localhost:7000/thing/1?_method=PUT

### Response

    HTTP/1.1 404 Not Found
    Date: Thu, 24 Feb 2011 12:36:32 GMT
    Status: 404 Not Found
    Connection: close
    Content-Type: text/html;charset=utf-8
    Content-Length: 35

    {"status":404,"reason":"Not found"}

## Delete a Thing

### Request

`DELETE /thing/id`

    curl -i -H 'Accept: application/json' -X DELETE http://localhost:7000/thing/1/

### Response

    HTTP/1.1 204 No Content
    Date: Thu, 24 Feb 2011 12:36:32 GMT
    Status: 204 No Content
    Connection: close


## Try to delete same Thing again

### Request

`DELETE /thing/id`

    curl -i -H 'Accept: application/json' -X DELETE http://localhost:7000/thing/1/

### Response

    HTTP/1.1 404 Not Found
    Date: Thu, 24 Feb 2011 12:36:32 GMT
    Status: 404 Not Found
    Connection: close
    Content-Type: application/json
    Content-Length: 35

    {"status":404,"reason":"Not found"}

## Get deleted Thing

### Request

`GET /thing/1`

    curl -i -H 'Accept: application/json' http://localhost:7000/thing/1

### Response

    HTTP/1.1 404 Not Found
    Date: Thu, 24 Feb 2011 12:36:33 GMT
    Status: 404 Not Found
    Connection: close
    Content-Type: application/json
    Content-Length: 35

    {"status":404,"reason":"Not found"}

## Delete a Thing using the _method hack

### Request

`DELETE /thing/id`

    curl -i -H 'Accept: application/json' -X POST -d'_method=DELETE' http://localhost:7000/thing/2/

### Response

    HTTP/1.1 204 No Content
    Date: Thu, 24 Feb 2011 12:36:33 GMT
    Status: 204 No Content
    Connection: close
