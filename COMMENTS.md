# Decisão da arquitetura utilizada

## Backend

![Swagger do backend](/mockups/back_end.png)

Arquitetura dividida em 4 camadas (API, Application, Domain e Infra) para aumentar a modularidade, reduzir a complexidade e facilitar mudanças futuras na arquiterura

#### API

A camada API é o coração da aplicação onde executamos a executamos e expomos os controllers para fazer requisições

Ao receber um request, validamos ele com a respectiva classe do FluentValidator, caso não esteja de acordo, retornamos 400BadRequest

![Bad request no back](/mockups/erro_validacao_back.png)

#### Application

A camada de aplicação é onde ficam os handlers para os comandos recebidos da API

Utilizamos a biblioteca MediatR para expor uma arquitetura consistindo de **Handlers**, **Inputs** e **Results** (ou DTO) para cada comando

Cada comando da camada application tem uma classe **Input** esperada, que quando recebida pelo MediatR é mandada para um **Handler** que executa o comando e retorna um **Result** (Assim como o DTO, retornamos essa classe ao invés da classe do Domain para não retornar informações desnecessárias ou reservadas)

Também declaramos aqui as classes de validação do FluentValidator para validação dos respectivos **Inputs**

#### Domain

A camada Domain é responsável por expor as entidades que vão ser usadas pelas camadas Domain e Application

#### Infra

A camada Infra expõe o EntityFramework para persistência de dados e guarda as migrations para mudanças no banco

#### Tests

Camada de testes usando XUnit, Moq, com um banco de dados EntityFrameworkCore.InMemory, foram criados testes para todos os Handlers da camada de Application

### Endpoints

#### Get /students

Retorna todos os alunos.

#### Post /students

Cria um novo aluno

O request é validado, caso não esteja de acordo, irá retornar 400BadRequest como resposta.

#### Get /students/{RA}

Recebe o Registro Acadêmico (unique key) como parâmetro e retorna o aluno.

Caso não encontre o aluno, retorna 404NotFound como resposta.

![Erro 404 not found no back](/mockups/erro_notfound_back.png)

#### Put /students/{RA}

Recebe o Registro Acadêmico (unique key) como parâmetro, email e nome como body

Altera email e nome do aluno (os outros parâmetros são imutáveis)

#### Delete /students/{RA}

Deleta o aluno com o RA recebido como parâmetro

## Frontend

![Tela do frontend](/mockups/front_end.png)

Os componentes foram separados nos arquivos views (telas) e components, views sendo responsáveis por fazer os requests para o backend e passar as responses para os components através de props.

O frontend foi desenvolvido usando typescript para melhor expor e integrar as funções dos serviços

Rotas foram colocadas em um arquivo routes.ts para fácil mudança das rotas caso necessário

Inputs são validados com rules de vue e vuefy
![Validação de inputs](/mockups/erro_validacao.png)

Funções com requests para o backend são agregadas em arquivos de suas respectivas entidades em utils/services para fácils acesso e modificação (StudentService.ts)

Erros de bad request no Frontend podem ser interceptados através do `axios.interceptors.request.use` e mostram um toast para o usuário em casos de bad request exibindo a mensagem personalizada de erro do FluentValidator através do vue-toastification

![Erro recebido do back](/mockups/erro_ra.png)
![Sucesso recebido do back](/mockups/criado_sucesso.png)

# Lista de bibliotecas de terceiros utilizadas (não indicadas no readme)

## Backend

- FluentValidation
- MediatR
- XUnit
- Moq (Para fazer o mock utilizado nos testes)
- EntityFrameworkCore.InMemory (Banco de dados temporário para execução de testes)

## Frontend

Setup através da Vue CLI com router, store, vuex

- Typescript
- Axios
- Axios-vue
- vue-toastification

# O que você melhoraria se tivesse mais tempo

- A validação com FluentValidation pode ser feita automaticamente através de middlewares, implementando `IPipelineBehavior<TRequest, TResponse>` do MediatR e não instanciando no controller
- Implementar as colunas da classe `AuditableEntity` no banco com valores default `Datetime.Now` para automaticamente salvar a data de criação e alteração de entidades
- O setup e teardown dos testes pode ser simplificado herdando de uma classe que implementa `IDisposable`
- A pesquisa de alunos por nome poderia ser feita através de parâmetros de url no request get /students e não somente filtrada no front

# Quais requisitos obrigatórios que não foram entregues