# Módulo de Cadastro de Categorias de Produtos - BrechoApp

## Resumo da Implementação

Este módulo implementa um sistema completo de gerenciamento de categorias de produtos, substituindo o campo de texto livre anterior por um sistema estruturado e gerenciável.

## Arquivos Criados

### 1. Modelo de Dados
- **BrechoApp/Models/Categoria.cs**
  - Propriedades: Id, NomeCategoria, DataCriacao
  - Armazenamento estruturado de categorias

### 2. Repositório de Dados
- **BrechoApp/Data/CategoriaRepository.cs**
  - `ListarTodas()` - Lista todas as categorias ordenadas por nome
  - `Adicionar(Categoria)` - Adiciona nova categoria
  - `Atualizar(Categoria)` - Atualiza categoria existente
  - `Excluir(int id)` - Exclui categoria por ID
  - `Existe(string nome, int? idExcluir)` - Verifica duplicatas

### 3. Interface de Usuário
- **BrechoApp/FormCadastroCategorias.cs** e **.Designer.cs**
  - Formulário Windows Forms completo
  - DataGridView para listagem
  - Botões: Adicionar, Editar, Excluir, Voltar
  - Validações de campos obrigatórios e duplicatas
  - Confirmação para exclusão

## Modificações em Arquivos Existentes

### 1. Banco de Dados
- **BrechoApp/Data/DatabaseInitializer.cs**
  - Nova tabela: `Categorias` com campos Id, NomeCategoria (UNIQUE), DataCriacao

### 2. Menu de Operações
- **BrechoApp/FormOperacoes.cs** e **.Designer.cs**
  - Novo botão: "Cadastro de Categorias de Produtos"
  - Altura do formulário aumentada para 660px
  - Botão Voltar reposicionado para Y=580

### 3. Cadastro de Itens
- **BrechoApp/FormItemLote.cs** e **.Designer.cs**
  - Campo `txtCategoria` (TextBox) substituído por `cboCategoria` (ComboBox)
  - ComboBox permite digitação livre (DropDownStyle.DropDown)
  - Método `CarregarCategorias()` popula o dropdown
  - Mensagem de aviso quando não há categorias

## Fluxo de Uso

1. **Cadastrar Categorias:**
   - Menu Principal → Operações → Cadastro de Categorias de Produtos
   - Adicionar categorias como: "Roupas Masculinas", "Calçados", etc.

2. **Usar Categorias nos Itens:**
   - Ao criar/editar itens de lote, o campo Categoria exibe as opções cadastradas
   - Usuário pode selecionar da lista ou digitar manualmente

## Validações Implementadas

✅ Nome de categoria obrigatório
✅ Verificação de duplicatas (case-sensitive)
✅ Confirmação antes de excluir
✅ Aviso quando não há categorias cadastradas
✅ Formato de data consistente (yyyy-MM-dd HH:mm:ss)

## Segurança

✅ Sem vulnerabilidades detectadas pelo CodeQL
✅ Uso de parâmetros SQL para evitar SQL injection
✅ DateTime.ParseExact com InvariantCulture para consistência
✅ Validação de entrada em todos os campos

## Build e Testes

✅ Build realizado com sucesso (0 erros)
✅ 135 warnings (pré-existentes, não relacionados a este módulo)
✅ Código compilado e validado
✅ Revisão de código realizada

## Estrutura do Banco de Dados

```sql
CREATE TABLE IF NOT EXISTS Categorias (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    NomeCategoria TEXT NOT NULL UNIQUE,
    DataCriacao TEXT NOT NULL
);
```

## Próximos Passos (Opcional)

- Adicionar campo de descrição nas categorias
- Implementar categorias hierárquicas (categorias e subcategorias)
- Adicionar ícones/cores para categorias
- Relatório de produtos por categoria
- Migração de dados: converter categorias de texto livre existentes

## Notas Técnicas

- SQLite não suporta ALTER TABLE, então mudanças no schema requerem recriar o banco
- ComboBox com DropDownStyle.DropDown permite entrada livre para flexibilidade
- Categorias ordenadas alfabeticamente na listagem
- Constraint UNIQUE no banco previne duplicatas no nível de dados
