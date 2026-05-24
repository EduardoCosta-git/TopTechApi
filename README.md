# TopTech API 💻🔧

API RESTful desenvolvida em C# com ASP.NET Core e Entity Framework Core para o Sistema de Gestão de Ordens de Serviço (Assistência Técnica de Informática).

Trabalho prático da disciplina de Plataforma de Desenvolvimento de Software, desenvolvido de forma incremental em três sprints. (1/3)

## 📌 Proposta do Tema e Justificativa
**Tema:** Sistema de Gestão de Cadastros, Manutenções e Peças (TopTech).

**Justificativa:** O sistema visa resolver o problema de organização em assistências técnicas de informática. Ele permite o registro estruturado de clientes, o acompanhamento do status das manutenções em computadores e o controle das peças/serviços utilizados pelos técnicos em cada ordem de serviço, garantindo maior controle operacional e agilidade no atendimento.

## ⚙️ Tecnologias Utilizadas
* **Linguagem:** C# (.NET 8)
* **Framework:** ASP.NET Core Web API
* **ORM:** Entity Framework Core
* **Banco de Dados:** SQLite

## 🗂️ Entidades do Sistema
O domínio do problema conta com 8 entidades interligadas para garantir a coesão do sistema:
1. `Cliente`
2. `Computador`
3. `Tecnico`
4. `OrdemServico`
5. `Peca`
6. `Servico`
7. `Pagamento`
8. `CategoriaPeca`

## 📊 Diagrama ER (Entidade-Relacionamento)
Abaixo está a representação estrutural do banco de dados e seus relacionamentos (1:N e N:M) exigidos no projeto:

```mermaid
erDiagram
    CLIENTE ||--o{ COMPUTADOR : possui
    COMPUTADOR ||--o{ ORDEM_SERVICO : recebe
    TECNICO ||--o{ ORDEM_SERVICO : atende
    
    ORDEM_SERVICO }|--|{ PECA : utiliza
    CATEGORIA_PECA ||--o{ PECA : classifica
    
    ORDEM_SERVICO }|--|{ SERVICO : inclui
    ORDEM_SERVICO ||--o{ PAGAMENTO : gera
