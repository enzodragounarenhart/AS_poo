# AS Programação Orientada a Objetos
## Autor: Enzo Dragoun Arenhart

<details><summary>Requests de HTTP</summary>
HTTP requests:

    GET:
        127.0.0.1:5034/livro
            Retorna todos os livros cadastrados no banco de dados.
        127.0.0.1:5034/livro/{id}
            Retorna o livro cujo id corresponde ao id escrito no GET request.
            
        127.0.0.1:5034/autor
            Retorna todos os autores cadastrados no banco de dados.
        127.0.0.1:5034/autor/{id}
            Retorna o autor cujo id corresponde ao id escrito no GET request.
        
        127.0.0.1:5034/usuario
            Retorna todos os usuarios cadastrados no banco de dados.
        127.0.0.1:5034/usuario/{id}
            Retorna o usuario cujo id corresponde ao id escrito no GET request.

    POST:
        127.0.0.1:5034/livro
            Insere um livro com dados escritos no body da request, formatado em JSON.
            Exemplo: 
                {
                    "nome": "nome",
                    "paginas": 100,
                    "genero": "genero",
                    "emprestado": 1, correspone se o livro esta emprestado, sendo 0 nao emprestado e 1 emprestado.
                    "ano": 1032,
                    "UsuarioId": 1, corresponde ao id do usuario que esta emprestando o livro, pode ser null.
                }
        
        127.0.0.1:5034/autor
            Insere um autor com dados escritos no body da request, formatado em JSON.
            Exemplo:
                {
                    "nome": "autor",
                    "cpf": "123.456.789-01",
                    "endereco": "Rua nome da rua 100",
                    "contato": "(51)12345-6789"
                }
        
        127.0.0.1:5034/usuario
            Insere um usuario com dados escritos no body da request, formatado em JSON.
            Exemplo:
                {
                    "nome": "usuario",
                    "cpf": "234.567.890-12",
                    "endereco": "Rua nome da rua 100",
                    "contato": "(51)23456-7890"
                }

    PUT:
        127.0.0.1:5034/livro/{id}
            Atualiza o livro cujo id corresponde ao id escrito no PUT request.
            Exemplo:
            {
                "id": 1,         obs.: o id dentro do body do request tem que ser igual ao o id no request
                "nome": "nome romance",
                "paginas": 105,
                "genero": "romance",
                "emprestado": 0,
                "ano": 1990,
                "usuarioId": null
            }

        127.0.0.1:5034/autor/{id}
            Atualiza o autor cujo id corresponde ao id escrito no PUT request.
            Exemplo:
            {
                "id": 1,         obs.: o id dentro do body do request tem que ser igual ao o id no request
                "nome": "autor2",
                "cpf": "333.333.333-33",
                "endereco": "Rua Centro 111",
                "contato": "(51)98765-4321"
            }

        127.0.0.1:5034/usuario/{id}
            Atualiza o usuario cujo id corresponde ao id escrito no PUT request.
            Exemplo:
            {
                "id": 1,         obs.: o id dentro do body do request tem que ser igual ao o id no request
                "nome": "usuario2",
                "cpf": "555777.777.777-77",
                "endereco": "Rua Another 111",
                "contato": "(51)09876-5432"
            }
        127.0.0.1:5034/usuario/{idUsuario}/emprestar/{idLivro}
            Empresta um livro para o usuario especificado

        127.0.0.1:5034/usuario/{idUsuario}/devolver/{idLivro}
            Devolve um usuario especifico livro do usuario especificado


    DELETE:
        127.0.0.1:5034/livro/{id}
            Deleta o livro especificado do banco de dados
        
        127.0.0.1:5034/livro/{id}
            Deleta o livro especificado do banco de dados
        
        127.0.0.1:5034/livro/{id}
            Deleta o livro especificado do banco de dados
</details>
