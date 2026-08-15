# Árvore Mercadológica API

API REST em **.NET 10 / ASP.NET Core** para gestão dos grupos da árvore mercadológica (comissão, compra e desconto), construída em camadas com **Entity Framework Core**.

> Projeto originado de um treinamento interno. Esta versão pública usa **banco de dados em memória** (EF Core InMemory), então roda sem nenhuma infraestrutura externa.

## Arquitetura

```
TreinamentoDEV.slnx
├── Domain          → Entidades e contratos de repositório (sem dependências externas)
├── Infra           → EF Core: DbContext, mapeamentos, repositórios (genérico + específicos) e seed
├── Application     → Services, DTOs e o envelope de resposta RespostaDTO<T>
└── TreinamentoDEV  → API: controllers, middleware de exceção, DI e Swagger
```

Decisões de design:

- **Repositório genérico** (`GenericRepository<T>`) com repositórios específicos por entidade.
- **Envelope `RespostaDTO<T>`**: os services retornam status + dados via factory methods (`Sucesso`, `Created`, `NotFound`, `BadRequest`); o controller apenas traduz o `StatusCode`.
- **Persistência controlada pelo service**: o repositório expõe `SaveChangesAsync`, mas quem decide quando persistir é a camada de aplicação.
- **Middleware de exceção** centraliza erros não tratados em resposta 500 padronizada.
- Entidades usam chave composta (`Codigo` + `CdEmpresa`), refletindo o modelo multiempresa original.

## Como rodar

Pré-requisito: [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
dotnet run --project TreinamentoDEV
```

A API sobe em `http://localhost:5253` com Swagger em `http://localhost:5253/swagger`. O banco em memória já inicia com dados de exemplo (seed).

## Endpoints

Base: `/ArvoreMercadologica`

| Método | Rota | Descrição |
|---|---|---|
| GET | `/` | Lista a árvore completa (todos os grupos) |
| GET | `/pesquisar?descricao=` | Pesquisa grupos pela descrição |
| GET/POST | `/grupo-comissao` | Lista / cria grupo de comissão |
| GET/PUT/DELETE | `/grupo-comissao/{codigo}` | Busca / altera / remove grupo de comissão |
| GET/POST | `/grupo-compra` | Lista / cria grupo de compra |
| GET/PUT/DELETE | `/grupo-compra/{codigo}` | Busca / altera / remove grupo de compra |
| GET/POST | `/grupo-desconto` | Lista / cria grupo de desconto |
| GET/PUT/DELETE | `/grupo-desconto/{codigo}` | Busca / altera / remove grupo de desconto |

Todas as respostas seguem o formato:

```json
{
  "sucesso": true,
  "statusCode": 200,
  "mensagem": "",
  "value": { }
}
```
