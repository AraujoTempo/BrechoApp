# Módulo: Cadastrar Comissão de Vendedores

## 📌 Visão Geral

Este módulo implementa o cadastro, edição e exclusão de comissões para vendedores no BrechoApp. O sistema permite gerenciar o percentual de comissão que cada vendedor receberá sobre suas vendas.

## 🎯 Objetivo

Permitir o cadastro de percentuais de comissão para Parceiros de Negócio do tipo "Vendedor", garantindo que cada vendedor tenha apenas uma comissão cadastrada, que poderá ser utilizada futuramente no cálculo automático de comissões sobre vendas.

## 📋 Funcionalidades

### 1. Cadastrar Comissão
- Seleção de vendedor através de ComboBox filtrada
- Entrada de percentual de comissão (0-100%)
- Validação automática de dados
- Registro de data de cadastro

### 2. Editar Comissão
- Seleção de comissão existente na grid
- Carregamento automático dos dados
- Atualização do percentual
- Registro de data de alteração

### 3. Excluir Comissão
- Seleção de comissão na grid
- Confirmação antes da exclusão
- Remoção do banco de dados

### 4. Listar Comissões
- Grid com todas as comissões cadastradas
- Ordenação por nome do vendedor
- Exibição de datas de cadastro e alteração

## 🗂️ Estrutura de Arquivos

```
BrechoApp/
├── Models/
│   └── ComissaoVendedor.cs          # Modelo de dados
├── Data/
│   ├── ComissaoVendedorRepository.cs # Repositório CRUD
│   └── DatabaseInitializer.cs        # Schema do banco (modificado)
├── FormCadastroComissaoVendedor.cs        # Código do formulário
├── FormCadastroComissaoVendedor.Designer.cs # Design do formulário
└── FormCadastroComissaoVendedor.resx      # Recursos do formulário
```

## 💾 Banco de Dados

### Tabela: ComissoesVendedores

```sql
CREATE TABLE ComissoesVendedores (
    IdComissao INTEGER PRIMARY KEY AUTOINCREMENT,
    CodigoPN TEXT NOT NULL UNIQUE,
    PercentualComissao REAL NOT NULL,
    DataCadastro TEXT NOT NULL,
    DataUltimaAlteracao TEXT,
    FOREIGN KEY (CodigoPN) REFERENCES ParceirosNegocio (CodigoParceiro)
);
```

### Campos

| Campo | Tipo | Descrição |
|-------|------|-----------|
| IdComissao | INTEGER | ID único (auto incremento) |
| CodigoPN | TEXT | Código do Parceiro (FK + UNIQUE) |
| PercentualComissao | REAL | Percentual (0.00-100.00) |
| DataCadastro | TEXT | Data/hora do cadastro |
| DataUltimaAlteracao | TEXT | Data/hora da última alteração (NULL se nunca editada) |

### Constraints

- **PRIMARY KEY:** IdComissao
- **FOREIGN KEY:** CodigoPN → ParceirosNegocio.CodigoParceiro
- **UNIQUE:** CodigoPN (garante uma comissão por vendedor)

## 🔐 Validações

### Validações de Entrada
- ✅ Vendedor obrigatório
- ✅ Percentual obrigatório
- ✅ Percentual numérico válido
- ✅ Percentual entre 0 e 100

### Validações de Negócio
- ✅ Parceiro deve existir
- ✅ Parceiro deve ser tipo Vendedor ou Socio
- ✅ Um vendedor pode ter apenas uma comissão
- ✅ Confirmação antes de excluir

## 🎨 Interface

### Componentes

- **ComboBox (cmbVendedor):** Lista de vendedores
- **TextBox (txtPercentual):** Entrada do percentual
- **Button (btnSalvar):** Salvar comissão
- **Button (btnNovo):** Limpar campos
- **Button (btnExcluir):** Excluir comissão
- **DataGridView (dgvComissoes):** Lista de comissões
- **Button (btnVoltar):** Fechar formulário

### Cores

| Botão | Cor | Hex |
|-------|-----|-----|
| Salvar | Verde | #46CC71 |
| Novo | Azul | #3498DB |
| Excluir | Vermelho | #E74C3C |
| Voltar | Cinza | #7F8C8D |

## 📝 Como Usar

### Cadastrar Nova Comissão

1. Abrir o menu **OPERAÇÕES**
2. Clicar em **Cadastrar Comissão de Vendedores**
3. Selecionar o vendedor na ComboBox
4. Informar o percentual (ex: 7.5)
5. Clicar em **Salvar**
6. Confirmar a mensagem de sucesso

### Editar Comissão Existente

1. Selecionar a comissão na grid
2. Os dados são carregados automaticamente
3. Alterar o percentual
4. Clicar em **Salvar**
5. Confirmar a mensagem de atualização

### Excluir Comissão

1. Selecionar a comissão na grid
2. Clicar em **Excluir**
3. Confirmar a exclusão na janela de diálogo
4. Confirmar a mensagem de sucesso

## 🔄 Fluxo de Dados

```
Usuário → FormCadastroComissaoVendedor
            ↓
     ComissaoVendedorRepository
            ↓
    ParceiroNegocioRepository (validação)
            ↓
        SQLite Database
```

## 📊 Regras de Negócio

1. **Unicidade:** Cada vendedor pode ter apenas UMA comissão cadastrada
2. **Tipo de Parceiro:** Apenas vendedores (TipoParceiro = Vendedor ou Socio)
3. **Range:** Percentual deve ser > 0 e <= 100
4. **Auditoria:** Sistema registra data de cadastro e última alteração
5. **Validação:** Não permite cadastro de comissão para parceiro inexistente

## 🔍 Exemplo de Uso

```csharp
// Criar uma nova comissão
var comissao = new ComissaoVendedor
{
    CodigoPN = "PN1",
    PercentualComissao = 7.5m
};

// Salvar (com validações)
var repo = new ComissaoVendedorRepository();
repo.Salvar(comissao);

// Buscar comissão de um vendedor
var comissaoVendedor = repo.BuscarPorCodigoPN("PN1");

// Listar todas
var todasComissoes = repo.ListarTodas();
```

## 🚀 Integração Futura

Este módulo prepara o sistema para:

1. **Cálculo Automático:** Calcular comissões durante vendas
2. **Relatórios:** Gerar relatórios de comissões a pagar
3. **Financeiro:** Integração com módulo de pagamentos
4. **Histórico:** Rastreamento de alterações de comissões

## 🛠️ Manutenção

### Adicionar Novo Campo

1. Atualizar `ComissaoVendedor.cs`
2. Modificar `DatabaseInitializer.cs` (adicionar campo)
3. Atualizar `ComissaoVendedorRepository.cs` (queries)
4. Modificar `FormCadastroComissaoVendedor.cs` (UI)
5. **IMPORTANTE:** Excluir arquivo `brecho.db` para recriar schema

### Alterar Validações

1. Modificar `ComissaoVendedorRepository.Salvar()`
2. Atualizar validações em `FormCadastroComissaoVendedor.btnSalvar_Click()`

## 📖 Referências

- **Especificação Original:** Issue/PR que solicitou esta funcionalidade
- **Padrão de Código:** Segue padrões do BrechoApp
- **Documentação SQLite:** https://www.sqlite.org/docs.html

## ⚠️ Observações Importantes

1. **Backup:** Sempre faça backup antes de modificar o schema
2. **Testing:** Teste em ambiente de desenvolvimento primeiro
3. **Dados:** A exclusão de comissão não afeta o Parceiro de Negócio
4. **Performance:** Queries otimizadas com JOINs e índices

## 🆘 Troubleshooting

### Comissão não aparece na lista
- Verificar se o parceiro é do tipo Vendedor ou Socio
- Confirmar que a comissão foi salva no banco

### Erro ao salvar comissão duplicada
- Cada vendedor pode ter apenas UMA comissão
- Edite a comissão existente ao invés de criar nova

### Percentual não aceita vírgula
- O sistema aceita vírgula e ponto
- Conversão automática para formato invariante

---

**Versão:** 1.0.0  
**Data:** 17/02/2026  
**Status:** ✅ Implementado e Testado
